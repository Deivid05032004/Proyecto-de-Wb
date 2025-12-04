
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface ICommandsCustomerRepository : IUnitOfWork
    {
        Task CreateCustomer(CustomerAggregate customer);
        Task UpdateCustomer(CustomerAggregate customer);
        Task<IEnumerable<CustomerAggregate>> GetAllCustomers();
        Task DeleteCustomer(CustomerAggregate customer);
        Task<CustomerAggregate> GetCustomerById(int id);

    }
}
