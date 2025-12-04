

namespace Billing.Sales.Backend.Repositories.Repositories
{
    public class CustomerCommandsRepository(IBillingSalesCommandDataContext context) : ICommandsCustomerRepository
    {
        public async Task CreateCustomer(CustomerAggregate customer)
        {
            await context.AddCustomerAsync(customer);
        }

        public async Task DeleteCustomer(CustomerAggregate customer)
        {
            await context.DeleteCustomerAsync(customer);
        }

        public async Task<IEnumerable<CustomerAggregate>> GetAllCustomers()
        {
            var customer = await context.GetAllCustomersAsync();
            return customer.Select(CustomerAggregate.FromEntity);
        }

        public async Task<CustomerAggregate> GetCustomerById(int id)
        {
            var customer = await context.GetCustomerByIdAsync(id);

            if (customer is null) 
            {
                return null;
            }
            return CustomerAggregate.FromEntity(customer);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(CustomerAggregate customer)
        {
           await context.UpdateCustomerAsync(customer);
        }
    }
}
