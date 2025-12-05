using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;
using Billing.Sales.Entities.Dtos.CreateUser;
using UpdateUserDto = Billing.Sales.Entities.Dtos.CreateUser.UpdateUserDto;

namespace Billing.Sales.Backend.BusinessObjects.Aggregates;

public class UserAggregate : User
{
    // -------------------------------------------------------------
    // Crear UserAggregate desde CreateUserDto (registro)
    // -------------------------------------------------------------
    public static UserAggregate CreateUserFrom(CreateUserDto dto, string hashedPassword)
    {
        return new UserAggregate
        {
            Email = dto.Email,
            PasswordHash = hashedPassword,   // importante: nunca guardar la contraseña en texto plano
            FailedLoginAttempts = 0,
            IsBlocked = false,
            BlockedAt = null
        };
    }

    // -------------------------------------------------------------
    // Actualizar UserAggregate desde UpdateUserDto
    // -------------------------------------------------------------
    public void UpdateUserFrom(UpdateUserDto dto)
    {
        // Se actualizan solo los campos que pueden cambiar
        Email = dto.Email ?? Email;

        // Si viene un cambio de contraseña, debe venir ya hasheada
        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            PasswordHash = dto.Password;
        }

        //// Opcional según tu negocio:
        //if (dto.ResetFailedAttempts)
        //{
        //    FailedLoginAttempts = 0;
        //}

        //if (dto.UnblockUser)
        //{
        //    IsBlocked = false;
        //    BlockedAt = null;
        //}
    }

    // -------------------------------------------------------------
    // Convertir una entidad User → UserAggregate
    // -------------------------------------------------------------
    public static UserAggregate FromEntity(User entity)
    {
        return new UserAggregate
        {
            Id = entity.Id,
            Email = entity.Email,
            PasswordHash = entity.PasswordHash,
            FailedLoginAttempts = entity.FailedLoginAttempts,
            IsBlocked = entity.IsBlocked,
            BlockedAt = entity.BlockedAt
        };
    }
}
