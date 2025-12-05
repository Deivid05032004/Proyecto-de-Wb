using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories;

public interface IUserRepository : IUnitOfWork
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> GetUserById(int id);
    Task CreateUser(User user);
    Task<IEnumerable<string>> GetRolesByUserId(int userId);
    Task<Role?> GetRoleByName(string roleName);
    Task EnsureRoleExists(string roleName);
    Task AssignRole(int userId, string roleName);
    Task UpdateUserAsync(User user);
    Task GetAllUsers();
}
