

using Billing.Sales.Backend.BusinessObjects.Interfaces.OrderDetails;

namespace Billing.Sales.Backend.UseCases.OrderDetailInteractor
{
    public class CreateOrderDetailInteractor(IOrderDetailOuputPort ouputPort, ICommandsOrderDetailsRepository repository) : IOrderDetailInputPort
    {
        public async Task HandleCreateOrderDetail(CreateOrderDetailsDto orderDetail)
        {
            var OrderDetail = OrderDetailAggregate.From(orderDetail);
            await repository.CreateOrderDetail(OrderDetail);
            await repository.SaveChanges();
            await ouputPort.PresentOrderDetail(OrderDetail);
        }

        public async Task HandleDeleteOrderDetail(int orderDetailId)
        {
            var orderDetail = await repository.GetOrderDetailById(orderDetailId);
            if (orderDetail == null)
            {
                await ouputPort.PresentOrderDetailDeleted(orderDetailId);
                return;
          
            }
            await repository.DeleteOrderDetail(orderDetail);
            await repository.SaveChanges();
            await ouputPort.PresentOrderDetailDeleted(orderDetailId);
        }

        public async Task HandleGetAllOrderDetails()
        {
            var ordesDetail = await repository.GetAllOrderDetails();
            //ouputPort.OrderDetailsList = ordesDetail
            return;
        }

        public Task HandleGetOrderDetailById(int orderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task HandleUpdateOrderDetail(int orderDetailId, CreateOrderDetailsDto orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
