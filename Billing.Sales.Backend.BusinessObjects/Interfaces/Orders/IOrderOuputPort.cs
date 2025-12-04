namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Orders
{
    public interface IOrderOutputPort
    {
        Task PresentOrderCreated(OrderAggregate order);

        Task PresentAllOrders();
        IEnumerable<OrderAggregate> OrdersList { get; set; }

        Task PresentOrderById(OrderAggregate? order);
        OrderAggregate? OrderById { get; set; }

        Task PresentOrderUpdated(int orderId, OrderAggregate? order);

        Task PresentOrderDeleted(int orderId);
    }
}

