using Billing.Sales.Backend.BusinessObjects;
using Billing.Sales.Backend.BusinessObjects.Interfaces.AuthPorts;
using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using BCrypt.Net;

namespace Billing.Sales.Backend.UseCases.AuthInteractor;

public class AuthInteractor : IAuthInputPort    
{

    private readonly IUserRepository _repository;
    private readonly IAuthOutputPort _outputPort;
    private readonly IConfiguration _config;

    public AuthInteractor(IUserRepository repository, IAuthOutputPort outputPort, IConfiguration config)
    {
        _repository = repository;
        _outputPort = outputPort;
        _config = config;
    }

    public async Task HandleLogin(LoginRequest req)
    {
        var user = await _repository.GetUserByEmail(req.Email);
        if (!IsValidEmail(req.Email))
        {
            throw new Exception("El correo debe contener al menos un '@'.");
        }
        // Usuario NO existe
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid credentials.");
        }
        // 1) Ya está bloqueado
        if (user.IsBlocked)
        {
            throw new UnauthorizedAccessException("User is blocked. Contact the administrator.");
        }
        // 2) Contraseña incorrecta
        if (!BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
        {
            user.FailedLoginAttempts++;

            // Si llega a 3 intentos fallidos -> bloquear
            if (user.FailedLoginAttempts >= 3)
            {
                user.IsBlocked = true;
                user.BlockedAt = DateTime.UtcNow;
            }

            await _repository.SaveChanges();

            var msg = user.IsBlocked
                ? "User has been blocked after 3 failed attempts."
                : $"Invalid credentials. Attempts: {user.FailedLoginAttempts}/3";

            throw new UnauthorizedAccessException(msg);
        }

        // ✔ Si la contraseña es correcta, reiniciar contador
        if (user.FailedLoginAttempts > 0)
        {
            user.FailedLoginAttempts = 0;
            await _repository.UpdateUserAsync(user);
        }

        // Obtener rol
        var role = (await _repository.GetRolesByUserId(user.Id)).FirstOrDefault() ?? "User";

        // Generar token JWT
        var token = GenerateJwtToken(user, role);

        _outputPort.LoginResponse = new LoginResponse
        {
            Token = token,
            UserName = user.Email,
            Role = role
        };
    }


    private string GenerateJwtToken(User user, string role)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(4),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task HandleRegister(RegisterUser request)
    {
        var existing = await _repository.GetUserByEmail(request.Email);
        if (existing != null)
            throw new Exception("Usuario ya registrado");
        if (!IsValidPassword(request.Password))
        {
            throw new Exception("La contraseña no cumple los requisitos: debe tener mayúscula, minúscula, número, caracter especial y longitud entre 4 y 10 caracteres.");
        }
        if (!IsValidEmail(request.Email))
        {
            throw new Exception("El correo debe contener al menos un '@'.");
        }


        var user = new User
        {
            Email = request.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _repository.CreateUser(user);
        await _repository.EnsureRoleExists(request.Role);
        await _repository.AssignRole(user.Id, request.Role);
        await _repository.SaveChanges();
    }


    private bool IsValidPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            return false;

        if (password.Length < 4 || password.Length > 10)
            return false;

        bool hasUpper = password.Any(char.IsUpper);
        bool hasLower = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);
        bool hasSpecial = password.Any(ch => !char.IsLetterOrDigit(ch));

        return hasUpper && hasLower && hasDigit && hasSpecial;
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }

    public async Task HandleUpdate(int id, UpdateUserDto u)
    {
        // 1. Buscar usuario
        var existingUser = await _repository.GetUserById(id);
        if (existingUser == null)
            throw new Exception("Usuario no encontrado");


        if (!string.IsNullOrWhiteSpace(u.Email) && !IsValidEmail(u.Email))
        {
            throw new Exception("El correo debe contener al menos un '@'.");
        }
        if (!string.IsNullOrWhiteSpace(u.Password) && !IsValidPassword(u.Password))
        {
            throw new Exception("La contraseña no cumple los requisitos: debe tener mayúscula, minúscula, número, caracter especial y longitud entre 4 y 10 caracteres.");
        }
        // 2. Actualizar campos SOLO si vienen en el DTO
        if (!string.IsNullOrWhiteSpace(u.Email))
        {
            existingUser.Email = u.Email;
        }


        existingUser.PasswordHash = !string.IsNullOrWhiteSpace(u.Password)
            ? BCrypt.Net.BCrypt.HashPassword(u.Password)
            : existingUser.PasswordHash;
        existingUser.FailedLoginAttempts = u.FailedLoginAttempts;
        existingUser.IsBlocked = u.IsBlocked;
        existingUser.BlockedAt = u.BlockedAt != 0
            ? DateTimeOffset.FromUnixTimeSeconds(u.BlockedAt).UtcDateTime
            : existingUser.BlockedAt;

        await _repository.UpdateUserAsync(existingUser);
    }

    public async Task GetAllUsers()
    {
        await _repository.GetAllUsers();
    }

    public async Task GetUserById(int id)
    {
        await _repository.GetUserById(id);
    }

}
