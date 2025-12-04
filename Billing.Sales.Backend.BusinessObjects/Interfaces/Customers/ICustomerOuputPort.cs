
using Billing.Sales.Backend.BusinessObjects.Aggregates;
using System.Threading.Tasks;

namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Customers;

public interface ICustomerOuputPort
{
    Task PresentCustomerCreated(CustomerAggregate customer);
    Task PresentAllCustomers(IEnumerable<CustomerAggregate> customers);
    IEnumerable<CustomerAggregate> CustomersList { get; set; }
    Task PresentCustomer(CustomerAggregate customer);
    Task PresentCustomerUpdated(int customerId ,CustomerAggregate customer);
    CustomerAggregate? CustomerById { get; set; }
    Task PresentCustomerDeleted(int customerId);

}
