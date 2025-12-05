using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;

namespace Billing.Sales.Fronend.Business.Objects.Interfaces;

public interface IUserGateway
{
    Task AddUserAsync(User user);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetUserByIdAsync(int id);

    Task<Role?> GetRoleByNameAsync(string roleName);
    Task<IEnumerable<string>> GetRolesByUserIdAsync(int userId);
    Task EnsureRoleExistsAsync(string roleName);
    Task AssignRoleAsync(int userId, string roleName);

    Task SaveChangesAsync();
    Task UpdateUserAsync(User user);
}
