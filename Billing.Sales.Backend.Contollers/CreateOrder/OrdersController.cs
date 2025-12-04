

using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;

namespace Billing.Sales.Backend.Contollers.CreateOrder
{
    public static class OrdersController
    {
        public static WebApplication UseOrderController(this WebApplication app)
        {
            app.MapPost(EndPoints.Orders, CreateOrder);
            app.MapGet(EndPoints.Orders,GetAllOrders);
            app.MapGet(EndPoints.Orders, GetOrderById);
            app.MapPut(EndPoints.Products, UpdateOrder);
            app.MapDelete(EndPoints.Orders, DeleteOrder);

            return app;
        }
        private static async Task<int> CreateOrder(
            CreateOrderDto dto,
            IOrderInputPort inputPort,
            IOrderOutputPort outputPort) 
        {
            await inputPort.HandleCreateOrder(dto);
            return outputPort.OrderById.Id;
        }

        private static async Task<IEnumerable<object>> GetAllOrders(
            IOrderInputPort inputPort,
            IOrderOutputPort outputPort) 
        {
            await inputPort.HandleGetAllOrders();
            return outputPort.OrdersList.Select(o => new 
            {
                o.Id,
                o.CustomerId,
                o.OrderDate,
                o.Total
            });
        }
        private static async Task<object> GetOrderById(
            int id,
            IOrderInputPort inputPort,
            IOrderOutputPort outputPort)
        {
            await inputPort.HandleGetOrderById(id);
            if (outputPort.OrderById == null) 
            {
                return null;
            }
            return new 
            {
                outputPort.OrderById.Id,
                outputPort.OrderById.CustomerId,
                outputPort.OrderById.OrderDate,
                outputPort.OrderById.Total
            
            };
        }
        private static async Task<bool> UpdateOrder(
            int id,
            CreateOrderDto dto,
            IOrderInputPort inputPort,
            IOrderOutputPort outputPort) 
        {
            await inputPort.HandleUpdateOrder(id, dto);
            return true;

        }
        private static async Task<bool> DeleteOrder(
            int id,
            CreateOrderDto dto,
            IOrderInputPort inputPort,
            IOrderOutputPort outputPort) 
        {
            await inputPort.HandleDeleteOrder(id);
            return true;
        }
    }
}
