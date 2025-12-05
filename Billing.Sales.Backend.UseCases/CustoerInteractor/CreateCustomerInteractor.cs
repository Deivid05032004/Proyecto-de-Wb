

using Billing.Sales.Backend.BusinessObjects.POCOEntities;

namespace Billing.Sales.Backend.UseCases.CustoerInteractor;

public class CreateCustomerInteractor(ICustomerOuputPort ouputPort, ICommandsCustomerRepository repository) : ICustomerInputPort
{
    public async Task HandleCreateCustomer(CreateCustomerDto customerDto)
    {
        var customer = CustomerAggregate.From(customerDto);
        await repository.CreateCustomer(customer);
        await repository.SaveChanges();
        await ouputPort.PresentCustomerCreated(customer);

    }


    public async Task HandleUpdateCustomer(int customerId, CreateCustomerDto dto)
    {
        var customer = await repository.GetCustomerById(customerId);

        if (customer == null)
        {
            await ouputPort.PresentCustomerUpdated(customerId, null);
            return;
        }

        customer.UpdateFrom(dto);

        await repository.UpdateCustomer(customer);

        await repository.SaveChanges();

        await ouputPort.PresentCustomerUpdated(customerId, customer);

    }



    public async Task HandleGetAllCustomers()
    {
        var customers = await repository.GetAllCustomers();
        ouputPort.CustomersList = customers;

        await ouputPort.PresentAllCustomers(customers);
    }

    public async Task HandleGetCustomerById(int customerId)
    {
        var customers = await repository.GetCustomerById(customerId);
        ouputPort.CustomerById = customers;
        await ouputPort.PresentCustomer(customers);
    }
    public async Task HandleDeleteCustomer(int customerId)
    {
        var customer = await repository.GetCustomerById(customerId);
        if (customer == null) 
        {
            await ouputPort.PresentCustomerDeleted(customerId);
            return;
        }

        await repository.DeleteCustomer(customer);
        await repository.SaveChanges();
        await ouputPort.PresentCustomerDeleted(customerId);
    }
}
