



namespace Billing.Sales.Backend.Repositories.Repositories
{
    public class OrderDetailCommandsRepository(IBillingSalesCommandDataContext context) : ICommandsOrderDetailsRepository
    {
        public async Task CreateOrderDetail(OrderDetailAggregate orderDetail)
        {
            await context.AddOrderDetailAsync(orderDetail);
        }

        public async Task DeleteOrderDetail(OrderDetailAggregate orderDetail)
        {
            await context.DeleteOrderDetailAsync(orderDetail);
        }

        public async Task<IEnumerable<OrderDetailAggregate>> GetAllOrderDetails()
        {
            var orderDetail = await context.GetAllOrderDetailsAsync();
            return orderDetail.Select(OrderDetailAggregate.FromEntity);
        }

        public async Task<OrderDetailAggregate> GetOrderDetailById(int id)
        {
            var orderDetail = await context.GetOrderDetailByIdAsync(id);
            if (orderDetail is null) { return null; }
            return OrderDetailAggregate.FromEntity(orderDetail);
        }

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        public async Task UpdateOrderDetail(OrderDetailAggregate orderDetail)
        {
            await context.UpdateOrderDetailAsync(orderDetail);
        }
    }
}
