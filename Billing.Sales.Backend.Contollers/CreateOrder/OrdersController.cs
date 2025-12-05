
using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;
using Billing.Sales.Entities.Dtos.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Sales.Backend.Contollers.CreateOrder
{
    public static class OrdersController
    {
        public static WebApplication UseOrderController(this WebApplication app)
        {
            app.MapPost(EndPoints.Orders, CreateOrder);
            app.MapGet(EndPoints.Orders, GetAllOrders);
            app.MapGet(EndPoints.OrdersById, GetOrderById);
            app.MapPut(EndPoints.OrdersById, UpdateOrder);
            app.MapDelete(EndPoints.OrdersById, DeleteOrder);

            return app;
        }

        private static async Task<int> CreateOrder(
            [FromBody] CreateOrderDto dto,
            [FromServices] IOrderInputPort inputPort,
            [FromServices] IOrderOutputPort outputPort)
        {
            await inputPort.HandleCreateOrder(dto);
            return outputPort.OrderById.Id;
        }

        private static async Task<IEnumerable<object>> GetAllOrders(
            [FromServices] IOrderInputPort inputPort,
            [FromServices] IOrderOutputPort outputPort)
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

        private static async Task<object?> GetOrderById(
            int id,
            [FromServices] IOrderInputPort inputPort,
            [FromServices] IOrderOutputPort outputPort)
        {
            await inputPort.HandleGetOrderById(id);
            if (outputPort.OrderById == null)
                return null;

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
            [FromBody] CreateOrderDto dto,
            [FromServices] IOrderInputPort inputPort,
            [FromServices] IOrderOutputPort outputPort)
        {
            await inputPort.HandleUpdateOrder(id, dto);
            return true;
        }

        private static async Task<bool> DeleteOrder(
            int id,
            [FromServices] IOrderInputPort inputPort,
            [FromServices] IOrderOutputPort outputPort)
        {
            await inputPort.HandleDeleteOrder(id);
            return true;
        }
    }
}

