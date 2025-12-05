using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.BusinessObjects.Interfaces.AuthPorts;

public interface IAuthInputPort
{
    Task HandleLogin(LoginRequest req);
    Task HandleRegister(RegisterUser req);
    Task HandleUpdate(int req, UpdateUserDto dto);
    Task GetAllUsers();
    Task GetUserById(int id);


}
