

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
            ouputPort.OrderDetailsList = ordesDetail;
            await ouputPort.PresentAllOrderDetails(ordesDetail); 
        }

        public async Task HandleGetOrderDetailById(int orderDetailId)
        {
            var orderDetail = await repository.GetOrderDetailById(orderDetailId);
            ouputPort.PresentOrderDetailById(orderDetail);
        }

        public async Task HandleUpdateOrderDetail(int orderDetailId, CreateOrderDetailsDto orderDetail)
        {
            var exist = await repository.GetOrderDetailById(orderDetailId);
            if (exist == null)
            {
                ouputPort.PresentOrderDetailUpdated(orderDetailId, null);
                return;
            }
            exist.UpdateFrom(orderDetail);

            repository.UpdateOrderDetail(exist);
   

            await repository.SaveChanges();

            await ouputPort.PresentOrderDetailUpdated(orderDetailId, exist);


        }
    }
}
