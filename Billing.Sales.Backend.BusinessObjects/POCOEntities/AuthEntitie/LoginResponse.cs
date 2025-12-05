using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;

public class LoginResponse
{
    public string Token { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Role { get; set; } = null!;
}
