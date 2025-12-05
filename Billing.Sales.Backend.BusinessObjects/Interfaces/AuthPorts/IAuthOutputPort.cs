using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.BusinessObjects.Interfaces.AuthPorts;

public interface IAuthOutputPort
{
    LoginResponse? LoginResponse { get; set; }
    Task HandleLoginResponse(LoginResponse response);
    User? update { get; set; }
    Task<IEnumerable<User>> users { get; set; }
}
