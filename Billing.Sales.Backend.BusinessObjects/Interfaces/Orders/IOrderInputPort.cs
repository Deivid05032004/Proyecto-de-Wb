
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;

public interface IOrderInputPort
{
    Task HandleCreateOrder(CreateOrderDto order);
    Task HandleGetAllOrders();
    Task HandleUpdateOrder(int orderId, CreateOrderDto order);
    Task HandleDeleteOrder(int orderId);
    Task HandleGetOrderById(int orderId);
}
