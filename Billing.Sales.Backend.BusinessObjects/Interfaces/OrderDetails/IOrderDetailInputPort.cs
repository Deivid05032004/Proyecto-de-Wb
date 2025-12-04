
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;

public interface IOrderDetailInputPort
{
    Task HandleCreateOrderDetail(CreateOrderDetailsDto orderDetail);
    Task HandleGetAllOrderDetails();
    Task HandleUpdateOrderDetail(int orderDetailId, CreateOrderDetailsDto orderDetail);
    Task HandleDeleteOrderDetail(int orderDetailId);
    Task HandleGetOrderDetailById(int orderDetailId);
}
