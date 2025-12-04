
namespace Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories
{
    public interface ICommandsOrderRepository : IUnitOfWork
    {
        Task CreateOrder(OrderAggregate order);
        Task UpdateOrder(OrderAggregate order);
        Task<IEnumerable<OrderAggregate>> GetAllOrders();
        Task DeleteOrder(OrderAggregate order);
        Task<OrderAggregate> GetOrderById(int id);
    }
}
