

namespace Billing.Sales.Backend.Repositories.Interfaces.CustomerCommand
{
    public interface ICustomerBillingSalesCommandDataContext
    {
        
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task SavesChangesAsync();
    }
}
