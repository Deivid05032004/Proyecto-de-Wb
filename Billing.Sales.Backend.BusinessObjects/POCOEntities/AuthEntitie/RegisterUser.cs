using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;

public class RegisterUser
{
    public string Cedula { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = "User";
}
