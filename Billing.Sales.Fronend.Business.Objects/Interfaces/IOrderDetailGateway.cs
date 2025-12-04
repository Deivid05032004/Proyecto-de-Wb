
namespace Billing.Sales.Fronend.Business.Objects.Interfaces;

public interface IOrderDetailGateway
{
    Task<int> CreateOrderDetailAsync(CreateOrderDetailsDto detailDto);
    Task UpdateOrderDetailAsync(int idOrderDetail, CreateOrderDetailsDto detailDto);
    Task<IEnumerable<CreateOrderDetailsDto>> GetAllDetailsAsync();
    Task<CreateOrderDetailsDto> GetDetailById(int id);
    Task DeleteOrderDetailAsync(int id);
}
