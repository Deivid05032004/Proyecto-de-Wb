
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Customers;

public interface ICustomerInputPort
{
    Task HandleCreateCustomer(CreateCustomerDto customer);
    Task HandleGetAllCustomers();
    Task HandleUpdateCustomer(int customerId, CreateCustomerDto customer);
    Task HandleDeleteCustomer(int customerId);
    Task HandleGetCustomerById(int customerId);

}
