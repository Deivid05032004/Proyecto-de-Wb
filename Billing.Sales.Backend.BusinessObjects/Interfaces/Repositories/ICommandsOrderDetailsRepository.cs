
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface ICommandsOrderDetailsRepository : IUnitOfWork
    {
        Task CreateOrderDetail(OrderDetailAggregate orderDetail);
        Task UpdateOrderDetail(OrderDetailAggregate orderDetail);
        Task<IEnumerable<OrderDetailAggregate>> GetAllOrderDetails();
        Task DeleteOrderDetail(OrderDetailAggregate orderDetail);
        Task<OrderDetailAggregate> GetOrderDetailById(int id);
    }
}
