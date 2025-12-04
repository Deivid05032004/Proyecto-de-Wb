

using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;

namespace Billing.Sales.Backend.Presenters.OrdersPresenters
{
    public class CreateOrderPresenter : IOrderOutputPort
    {
        public IEnumerable<OrderAggregate> OrdersList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public OrderAggregate? OrderById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<OrderAggregate>? Orders { get; private set; }
        public OrderAggregate? Order { get; private set; }

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

        public Task PresentOrderDeleted(int orderId)
        {
            // Puedes registrar el ID si lo necesitas
            return Task.CompletedTask;
        }

        public Task PresentOrderUpdated(int orderId, OrderAggregate? order)
        {
            Order = order;
            return Task.CompletedTask;
        }
    }
}
