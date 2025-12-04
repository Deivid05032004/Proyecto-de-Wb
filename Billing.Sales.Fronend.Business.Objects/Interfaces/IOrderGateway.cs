

namespace Billing.Sales.Fronend.Business.Objects.Interfaces;

public interface IOrderGateway
{
    Task<int> CreateOrderAsync(CreateOrderDto orderDto);
    Task updateOrderAsync(int OrderId, CreateOrderDto orderDto);
    Task<IEnumerable<CreateOrderDto>> GetAllOrdersAsync();
    Task<CreateOrderDto> GetOrderByIdAsync(int id);
    Task DeleteOrderAsync(int id);


}
