using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Entities.Dtos.CreateUser;

public class UserRoleDto
{
    public int UserId { get; set; }
    public CreateUserDto User { get; set; } = null!;  // <- aquí usamos POCO User

    public int RoleId { get; set; }
    public CreateRoleDto Role { get; set; } = null!;
}
