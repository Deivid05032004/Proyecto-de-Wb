using Billing.Sales.Backend.BusinessObjects.POCOEntities;
using Billing.Sales.Backend.DataContext.EFCore.DataContext;
using Billing.Sales.Backend.DataContext.EFCore.Options;
using Billing.Sales.Backend.Repositories.Interfaces;
using Billing.Sales.Backend.Repositories.Interfaces.CustomerCommand;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Billing.Sales.Backend.DataContext.EFCore.Services.CustomerService;

internal class CustomerBillingSalesCommandsDataContext(IOptions<DBOptions> dboptions)
    : BillingSalesContext(dboptions), ICustomerBillingSalesCommandDataContext
{
    // ---------------------------------------------------------------------
    // CREATE
    // ---------------------------------------------------------------------
    public async Task AddCustomerAsync(Customer customer)
    {
        await AddAsync(customer);
    }

    public Task DeleteCustomerAsync(Customer customer)
    {
        Customer.Remove(customer);
        return Task.CompletedTask;
    }

    // ---------------------------------------------------------------------
    // READ (ALL)
    // ---------------------------------------------------------------------
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await Customer.ToListAsync();
    }

    // ---------------------------------------------------------------------
    // READ (BY ID)
    // ---------------------------------------------------------------------
    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await Customer.FirstOrDefaultAsync(x => x.Id == id);
    }

    // ---------------------------------------------------------------------
    // DELETE
    // ---------------------------------------------------------------------
    public Task RemoveCustomer(Customer customer)
    {
        Customer.Remove(customer);
        return Task.CompletedTask;
    }

    // ---------------------------------------------------------------------
    // SAVE CHANGES
    // ---------------------------------------------------------------------
    public async Task SavesChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    public Task UpdateCustomerAsync(Customer customer)
    {
        throw new NotImplementedException();
    }
}
