using Billing.Sales.Entities.Dtos.CreateBill;

public class OrderAggregate : Order
{
    private readonly List<OrderDetailAggregate> _details = new();
    public IReadOnlyCollection<OrderDetailAggregate> OrderDetails => _details.AsReadOnly();

    public void AddOrUpdateDetail(CreateOrderDetailsDto dto)
    {
        var existing = _details.FirstOrDefault(x => x.ProductId == dto.ProductId);

        if (existing != null)
        {
            existing.Quantity += dto.Quantity;
            return;
        }

        _details.Add(OrderDetailAggregate.From(dto));
    }

    public void ReplaceDetails(IEnumerable<CreateOrderDetailsDto> dtos)
    {
        _details.Clear();
        foreach (var d in dtos)
            _details.Add(OrderDetailAggregate.From(d));
    }

    public static OrderAggregate From(CreateOrderDto dto)
    {
        var order = new OrderAggregate
        {
            CustomerId = dto.CustomerId,
            OrderDate = dto.Date,
            InvoiceNumber = dto.InvoiceNumber,
            Total = dto.Total
        };

        foreach (var detail in dto.OrderDetails)
            order.AddOrUpdateDetail(detail);

        return order;
    }

    public void UpdateFrom(CreateOrderDto dto)
    {
        CustomerId = dto.CustomerId;
        OrderDate = dto.Date;
        InvoiceNumber = dto.InvoiceNumber;
        Total = dto.Total;

        // Reemplazar detalles completamente
        ReplaceDetails(dto.OrderDetails);
    }
    public static OrderAggregate FromEntity(Order entity)
    {
        var order = new OrderAggregate
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            OrderDate = entity.OrderDate,
            InvoiceNumber = entity.InvoiceNumber,
            Total = entity.Total
        };

        if (entity.OrderDetails != null)
        {
            foreach (var d in entity.OrderDetails)
                order._details.Add(OrderDetailAggregate.FromEntity(d));
        }

        return order;
    }
}
