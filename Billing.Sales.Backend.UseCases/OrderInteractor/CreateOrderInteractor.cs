using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;
using Billing.Sales.Backend.BusinessObjects.Interfaces.Repositories;

public class CreateOrderInteractor(
    IOrderOutputPort outputPort,ICommandsOrderRepository repository,ICommandsOrderDetailsRepository orderDetailRepository) : IOrderInputPort
{
    public async Task HandleCreateOrder(CreateOrderDto dto)
    {
        var order = OrderAggregate.From(dto);

        // 1) Guardar la orden (sin detalles todavía)
        await repository.CreateOrder(order);
        await repository.SaveChanges();

        // 2) Ahora guardar los detalles
        foreach (var detail in order.OrderDetails)
        {
            detail.OrderId = order.Id;
            await orderDetailRepository.CreateOrderDetail(detail);
        }

        await orderDetailRepository.SaveChanges();

        await outputPort.PresentOrderCreated(order);
    }

    public async Task HandleUpdateOrder(int orderId, CreateOrderDto dto)
    {
        var existing = await repository.GetOrderById(orderId);

        if (existing == null)
        {
            await outputPort.PresentOrderUpdated(orderId, null);
            return;
        }

        existing.UpdateFrom(dto);
        repository.UpdateOrder(existing);

        await repository.SaveChanges();

        await outputPort.PresentOrderUpdated(orderId, existing);
    }

    public async Task HandleDeleteOrder(int orderId)
    {
        var order = await repository.GetOrderById(orderId);

        if (order == null)
        {
            await outputPort.PresentOrderDeleted(orderId);
            return;
        }

        await repository.DeleteOrder(order);
        await repository.SaveChanges();

        await outputPort.PresentOrderDeleted(orderId);
    }

    public async Task HandleGetAllOrders()
    {
        var orders = await repository.GetAllOrders();

        outputPort.OrdersList = orders;
        await outputPort.PresentAllOrders(orders);
    }

    public async Task HandleGetOrderById(int orderId)
    {
        var order = await repository.GetOrderById(orderId);

        outputPort.OrderById = order;
        await outputPort.PresentOrderById(order);
    }
}
