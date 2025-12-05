using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Sales.Fronend.Gateways.UserGateway;

public class CreateUserGateway(HttpClient client) : IUserGateway
{
    public async Task AddUserAsync(User user)
    {
        using var response = await client.PostAsJsonAsync(EndPoints.Users, user);
    }

    public Task AssignRoleAsync(int userId, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task EnsureRoleExistsAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<Role?> GetRoleByNameAsync(string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> GetRolesByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}
