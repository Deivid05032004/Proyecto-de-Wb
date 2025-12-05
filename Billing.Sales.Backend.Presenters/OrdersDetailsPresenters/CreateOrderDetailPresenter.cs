using Billing.Sales.Backend.BusinessObjects.Aggregates;
using Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;

namespace Billing.Sales.Backend.Presenters.OrdersDetailsPresenters
{
    public class CreateOrderDetailPresenter : IOrderDetailOuputPort
    {
        // === PROPIEDADES INTERNAS ===
        public IEnumerable<OrderDetailAggregate> OrderDetails { get; private set; } = new List<OrderDetailAggregate>();
        public OrderDetailAggregate? OrderDetail { get; private set; }

        // === IMPLEMENTACIÓN EXPLÍCITA DE LA INTERFAZ ===

        IEnumerable<OrderDetailAggregate> IOrderDetailOuputPort.OrderDetailsList
        {
            get => OrderDetails;
            set => OrderDetails = value;
        }

        OrderDetailAggregate? IOrderDetailOuputPort.OrderDetailById
        {
            get => OrderDetail;
            set => OrderDetail = value;
        }

        // === MÉTODOS DEL OUTPUT PORT ===

        public Task PresentAllOrderDetails(IEnumerable<OrderDetailAggregate> orderDetails)
        {
            OrderDetails = orderDetails;
            return Task.CompletedTask;
        }

        public Task PresentOrderDetailById(OrderDetailAggregate? orderDetail)
        {
            OrderDetail = orderDetail;
            return Task.CompletedTask;
        }

        public Task PresentOrderDetailCreated(OrderDetailAggregate orderDetail)
        {
            OrderDetail = orderDetail;
            return Task.CompletedTask;
        }

        public Task PresentOrderDetailUpdated(int orderDetailId, OrderDetailAggregate? orderDetail)
        {
            OrderDetail = orderDetail;
            return Task.CompletedTask;
        }

        public Task PresentOrderDetailDeleted(int orderDetailId)
        {
            return Task.CompletedTask;
        }

        // Método corregido (solo este)
        public Task PresentOrderDetail(OrderDetailAggregate orderDetail)
        {
            OrderDetail = orderDetail;
            return Task.CompletedTask;
        }

    }
}
