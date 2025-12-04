

namespace Billing.Sales.Backend.Repositories.Interfaces.OrderDetailCommand
{
    public interface IOrderDetailBillingSalesCommandDataContext
    {
        // ============================
        // ORDER DETAILS
        // ============================
        Task AddOrderDetailAsync(OrderDetail detail);
        Task UpdateOrderDetailAsync(OrderDetail detail);
        Task DeleteOrderDetailAsync(OrderDetail detail);

        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int id);
        Task SavesChangesAsync();
    }
}
