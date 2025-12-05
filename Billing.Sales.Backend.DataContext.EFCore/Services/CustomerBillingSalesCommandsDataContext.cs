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
        await Customer.AddAsync(customer);
    }

    // ---------------------------------------------------------------------
    // GET ALL
    // ---------------------------------------------------------------------
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await Customer.AsNoTracking().ToListAsync();
    }

    // ---------------------------------------------------------------------
    // GET BY ID
    // ---------------------------------------------------------------------
    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await Customer.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    // ---------------------------------------------------------------------
    // UPDATE (SEGURO — SIN TRACKING DUPLICADO)
    // ---------------------------------------------------------------------
    public async Task UpdateCustomerAsync(Customer customer)
    {
        var existing = await Customer.FirstOrDefaultAsync(x => x.Id == customer.Id);

        if (existing == null)
            throw new Exception("Customer not found");

        // Actualizar propiedades
        existing.IdentificationNumber = customer.IdentificationNumber;
        existing.FirstName = customer.FirstName;
        existing.LastName = customer.LastName;
        existing.EmailAddress = customer.EmailAddress;
        existing.PhoneNumber = customer.PhoneNumber;
        existing.Address = customer.Address;
        existing.City = customer.City;
    }

    // ---------------------------------------------------------------------
    // DELETE (SEGURO — CARGA DESDE LA BD)
    // ---------------------------------------------------------------------
    public async Task DeleteCustomerAsync(Customer customer)
    {
        var existing = await Customer.FirstOrDefaultAsync(c => c.Id == customer.Id);

        if (existing == null)
            throw new Exception("Customer not found");

        Customer.Remove(existing);
    }

    // ---------------------------------------------------------------------
    // SAVE CHANGES
    // ---------------------------------------------------------------------
    public async Task SavesChangesAsync()
    {
        await base.SaveChangesAsync();
    } 
}
