

using Billing.Sales.Backend.BusinessObjects.Aggregates;
using Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;

namespace Billing.Sales.Backend.Presenters.OrdersDetailsPresenters
{
    public class CreateOrderDetailPresenter : IOrderDetailOuputPort
    {
        public IEnumerable<OrderDetailAggregate> OrderDetailsList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public OrderDetailAggregate? OrderDetailById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<OrderDetailAggregate>? OrderDetails { get; private set; }
        public OrderDetailAggregate? OrderDetail { get; private set; }

        public Task PresentAllOrderDetails(IEnumerable<OrderDetailAggregate> orderDetails)
        {
            OrderDetails = orderDetails;
            return Task.CompletedTask;
        }

        public Task PresentOrderDetail(OrderDetailAggregate orderDetail)
        {
            OrderDetail = orderDetail;
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

        public Task PresentOrderDetailDeleted(int orderDetailId)
        {
            return Task.CompletedTask;
        }

        public Task PresentOrderDetailUpdated(int orderDetailId, OrderDetailAggregate? orderDetail)
        {
            OrderDetail = orderDetail;
            return Task.CompletedTask;
        }
    }
}
