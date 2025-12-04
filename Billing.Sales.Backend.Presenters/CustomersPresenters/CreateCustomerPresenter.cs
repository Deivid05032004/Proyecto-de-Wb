

using Billing.Sales.Backend.BusinessObjects.Aggregates;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Customers;

namespace Billing.Sales.Backend.Presenters.CustomersPresenters
{
    public class CreateCustomerPresenter : ICustomerOuputPort
    {
        // === PROPIEDADES PARA EXPONER RESULTADOS ===
        public IEnumerable<CustomerAggregate> CustomersList { get; private set; } = new List<CustomerAggregate>();
        public CustomerAggregate? CustomerById { get; private set; }
        public int CreatedCustomerId { get; private set; }
        public int DeletedCustomerId { get; private set; }
        public int UpdatedCustomerId { get; private set; }
        IEnumerable<CustomerAggregate> ICustomerOuputPort.CustomersList { get => CustomersList; set => CustomersList = value; }
        CustomerAggregate? ICustomerOuputPort.CustomerById { get => CustomerById; set => CustomerById = value; }

        // === METODOS DEL OUTPUT PORT ===

        public Task PresentAllCustomers(IEnumerable<CustomerAggregate> customers)
        {
            CustomersList = customers;
            return Task.CompletedTask;
        }

   
        public Task PresentCustomer(CustomerAggregate customer)
        {
            CustomerById = customer;
            return Task.CompletedTask;
        }

        public Task PresentCustomerCreated(CustomerAggregate customer)
        {
            CreatedCustomerId = customer.Id;
            CustomerById = customer;
            return Task.CompletedTask;
        }

        public Task PresentCustomerDeleted(int customerId)
        {
            DeletedCustomerId = customerId;
            return Task.CompletedTask;
        }

        public Task PresentCustomerUpdated(int customerId, CustomerAggregate customer)
        {
            UpdatedCustomerId = customerId;
            CustomerById = customer;
            return Task.CompletedTask;
        }
    }
}
