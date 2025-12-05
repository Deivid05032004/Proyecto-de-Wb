
//using Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;

//namespace Billing.Sales.Backend.Contollers.CreateOrderDetail
//{
//    public static class OrderDetailController
//    {
//        public static WebApplication UseOrderDetailsController(this WebApplication app) 
//        {
//            app.MapPost(EndPoints.OrderDetail, CreateOrderDetail);
//            app.MapGet(EndPoints.OrderDetail, GetAllOrdersDetails);
//            app.MapGet(EndPoints.OrderDetail, GetOrderDetailById);
//            app.MapPut(EndPoints.OrderDetail, UpdateOrderDetail);
//            app.MapDelete(EndPoints.OrderDetail, DeleteOrderDetail);
//            return app;
//        }
//        private static async Task<int> CreateOrderDetail(
//            CreateOrderDetailsDto dto,
//            IOrderDetailInputPort inputPort,
//            IOrderDetailOuputPort ouputPort)
//        {
//            await inputPort.HandleCreateOrderDetail(dto);
//            return ouputPort.OrderDetailById.Id;
//        }
//        private static async Task<IEnumerable<object>> GetAllOrdersDetails(
//            IOrderDetailInputPort inputPort,
//            IOrderDetailOuputPort ouputPort)
//        {
//            await inputPort.HandleGetAllOrderDetails();
//            return ouputPort.OrderDetailsList.Select(od => new
//            {
//                od.Id,
//                od.OrderId,
//                od.ProductId,
//                od.UnitPrice,
//                od.Quantity,
//                od.TotalPrice

//            });
//        }
//        private static async Task<object> GetOrderDetailById(
//            int id,
//            IOrderDetailInputPort inputPort,
//            IOrderDetailOuputPort ouputPort)
//        {
//            await inputPort.HandleGetOrderDetailById(id);
//            if (ouputPort.OrderDetailById == null)
//            {
//                return null;
//            }
//            return new
//            {
//                ouputPort.OrderDetailById.Id,
//                ouputPort.OrderDetailById.OrderId,
//                ouputPort.OrderDetailById.ProductId,
//                ouputPort.OrderDetailById.UnitPrice,
//                ouputPort.OrderDetailById.Quantity,
//                ouputPort.OrderDetailById.TotalPrice
//            };
//        }
//        private static async Task<bool> UpdateOrderDetail(
//            int id,
//            CreateOrderDetailsDto dto,
//            IOrderDetailInputPort inputPort,
//            IOrderDetailOuputPort ouputPort)
//        {
//            await inputPort.HandleUpdateOrderDetail(id, dto);
//            return true;
//        }
//        private static async Task<bool> DeleteOrderDetail(
//            int id,
//            IOrderDetailInputPort inputPort,
//            IOrderDetailOuputPort ouputPort)

//        {
//            await inputPort.HandleDeleteOrderDetail(id);
//            return true;
//        }

//    }
//}
using Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;
using Billing.Sales.Entities.Dtos.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Sales.Backend.Contollers.CreateOrderDetail
{
    public static class OrderDetailController
    {
        public static WebApplication UseOrderDetailsController(this WebApplication app)
        {
            app.MapPost(EndPoints.OrderDetail, CreateOrderDetail);
            app.MapGet(EndPoints.OrderDetail, GetAllOrdersDetails);
            app.MapGet(EndPoints.OrderDetailById, GetOrderDetailById);
            app.MapPut(EndPoints.OrderDetailById, UpdateOrderDetail);
            app.MapDelete(EndPoints.OrderDetailById, DeleteOrderDetail);

            return app;
        }

        private static async Task<int> CreateOrderDetail(
            [FromBody] CreateOrderDetailsDto dto,
            [FromServices] IOrderDetailInputPort inputPort,
            [FromServices] IOrderDetailOuputPort ouputPort)
        {
            await inputPort.HandleCreateOrderDetail(dto);
            return ouputPort.OrderDetailById.Id;
        }

        private static async Task<IEnumerable<object>> GetAllOrdersDetails(
            [FromServices] IOrderDetailInputPort inputPort,
            [FromServices] IOrderDetailOuputPort ouputPort)
        {
            await inputPort.HandleGetAllOrderDetails();
            return ouputPort.OrderDetailsList.Select(od => new
            {
                od.Id,
                od.OrderId,
                od.ProductId,
                od.UnitPrice,
                od.Quantity,
                od.TotalPrice
            });
        }

        private static async Task<object?> GetOrderDetailById(
            int id,
            [FromServices] IOrderDetailInputPort inputPort,
            [FromServices] IOrderDetailOuputPort ouputPort)
        {
            await inputPort.HandleGetOrderDetailById(id);

            if (ouputPort.OrderDetailById == null)
                return null;

            return new
            {
                ouputPort.OrderDetailById.Id,
                ouputPort.OrderDetailById.OrderId,
                ouputPort.OrderDetailById.ProductId,
                ouputPort.OrderDetailById.UnitPrice,
                ouputPort.OrderDetailById.Quantity,
                ouputPort.OrderDetailById.TotalPrice
            };
        }

        private static async Task<bool> UpdateOrderDetail(
            int id,
            [FromBody] CreateOrderDetailsDto dto,
            [FromServices] IOrderDetailInputPort inputPort,
            [FromServices] IOrderDetailOuputPort ouputPort)
        {
            await inputPort.HandleUpdateOrderDetail(id, dto);
            return true;
        }

        private static async Task<bool> DeleteOrderDetail(
            int id,
            [FromServices] IOrderDetailInputPort inputPort,
            [FromServices] IOrderDetailOuputPort ouputPort)
        {
            await inputPort.HandleDeleteOrderDetail(id);
            return true;
        }

    }
}

