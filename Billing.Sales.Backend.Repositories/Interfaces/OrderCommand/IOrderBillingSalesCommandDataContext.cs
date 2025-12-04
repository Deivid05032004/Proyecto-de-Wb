

namespace Billing.Sales.Backend.Repositories.Interfaces.OrderCommand
{
    public interface IOrderBillingSalesCommandDataContext
    {
        // ============================
        // ORDERS
        // ============================
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);

        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task SavesChangesAsync();
    }
}
