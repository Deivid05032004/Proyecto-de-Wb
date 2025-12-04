
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;

public interface IOrderDetailOuputPort
{
    Task PresentOrderDetailCreated(OrderDetailAggregate orderDetail);
    Task PresentAllOrderDetails();
    IEnumerable<OrderDetailAggregate> OrderDetailsList { get; set; }
    Task PresentOrderDetail(OrderDetailAggregate orderDetail);
    OrderDetailAggregate? OrderDetailById { get; set; }
    Task PresentOrderDetailUpdated(int orderDetailId, OrderDetailAggregate orderDetail);
    Task PresentOrderDetailDeleted(int orderDetailId);
}
