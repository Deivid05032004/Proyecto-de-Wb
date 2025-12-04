using Billing.Sales.Backend.BusinessObjects.Interfaces.Orders;

public class CreateOrderInteractor(IOrderOutputPort outputPort, ICommandsOrderRepository repository): IOrderInputPort
{
    public async Task HandleCreateOrder(CreateOrderDto dto)
    {
        var order = OrderAggregate.From(dto);

        await repository.CreateOrder(order);
        await repository.SaveChanges();

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

        if (existing is OrderAggregate aggregate)
            aggregate.UpdateFrom(dto);
        else
            throw new Exception("El orden cargada no es un agregado válido");

        await repository.SaveChanges();

        await outputPort.PresentOrderUpdated(orderId, aggregate);
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
