using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Entities.Dtos.CreateUser;

public class CreateUserDto
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public int FailedLoginAttempts { get; set; }      // Nº de intentos fallidos
    public bool IsBlocked { get; set; }               // ¿Está bloqueado?
    public DateTime? BlockedAt { get; set; }          // Cuándo se bloqueó (opcional pero útil)


    public ICollection<UserRoleDto> UserRoles { get; set; } = new List<UserRoleDto>();
}
