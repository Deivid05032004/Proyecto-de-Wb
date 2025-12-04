
namespace Billing.Sales.Backend.Repositories.Repositories
{
    public class OrderCommandsRepository(IBillingSalesCommandDataContext context) : ICommandsOrderRepository
    {
        public async Task CreateOrder(OrderAggregate order)
        {
            await context.AddOrderAsync(order);
        }

        public async Task DeleteOrder(OrderAggregate order)
        {
            await context.DeleteOrderAsync(order);
        }

        public async Task<IEnumerable<OrderAggregate>> GetAllOrders()
        {
            var order = await context.GetAllOrdersAsync();
            return order.Select(OrderAggregate.FromEntity);
        }

        public async Task<OrderAggregate> GetOrderById(int id)
        {
            var order = await context.GetOrderByIdAsync(id);
            if (order is null)
            {
                return null;
            }
            return OrderAggregate.FromEntity(order);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateOrder(OrderAggregate order)
        {
            await context.UpdateOrderAsync(order);
        }
    }
}
