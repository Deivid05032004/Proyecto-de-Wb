using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Entities.Dtos.CreateUser;

public class UpdateUserDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public bool IsBlocked { get; set; }
    public int FailedLoginAttempts { get; set; }
    public int BlockedAt { get; set; }
}
