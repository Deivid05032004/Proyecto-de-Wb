using Billing.Sales.Backend.BusinessObjects.Aggregates;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;

namespace Billing.Sales.Backend.Presenters.OrdersPresenters
{
    public class CreateOrderPresenter : IOrderOutputPort
    {
        // === CAMPOS/PROPIEDADES INTERNAS ===
        public IEnumerable<OrderAggregate> Orders { get; private set; } = new List<OrderAggregate>();
        public OrderAggregate? Order { get; private set; }

        // === PROPIEDADES DE LA INTERFAZ (IMPLEMENTACIÓN EXPLÍCITA) ===
        IEnumerable<OrderAggregate> IOrderOutputPort.OrdersList
        {
            get => Orders;
            set => Orders = value;
        }

        OrderAggregate? IOrderOutputPort.OrderById
        {
            get => Order;
            set => Order = value;
        }

        // === MÉTODOS DEL OUTPUT PORT ===

        public Task PresentAllOrders(IEnumerable<OrderAggregate> orders)
        {
            Orders = orders;
            return Task.CompletedTask;
        }

        public Task PresentOrderById(OrderAggregate? order)
        {
            Order = order;
            return Task.CompletedTask;
        }

        public Task PresentOrderCreated(OrderAggregate order)
        {
            Order = order;
            return Task.CompletedTask;
        }

        public Task PresentOrderUpdated(int orderId, OrderAggregate? order)
        {
            Order = order;
            return Task.CompletedTask;
        }

        public Task PresentOrderDeleted(int orderId)
        {
            return Task.CompletedTask;
        }
    }
}
