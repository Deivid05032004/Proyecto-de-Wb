using Billing.Sales.Entities.Dtos.CreateBill;

public class OrderAggregate : Order
{
    // === LISTA REAL DE DETALLES ===
    private readonly List<OrderDetailAggregate> _details = new();
    public IReadOnlyCollection<OrderDetailAggregate> OrderDetails => _details.AsReadOnly();

    // ================================
    //   AGREGAR O ACTUALIZAR DETALLE
    // ================================
    public void AddOrUpdateDetail(CreateOrderDetailsDto dto)
    {
        var existing = _details.FirstOrDefault(x => x.ProductId == dto.ProductId);

        if (existing != null)
        {
            // Sumar cantidades
            existing.Quantity += dto.Quantity;

            // Actualizar precio unitario al nuevo precio (si aplica)
            existing.UnitPrice = (decimal)dto.SalePrice;

            return;
        }

        // Si no existe, crear el detalle
        _details.Add(OrderDetailAggregate.From(dto));
    }

    // ====================================
    //  REEMPLAZAR DETALLES (UPDATE ORDER)
    // ====================================
    public void ReplaceDetails(IEnumerable<CreateOrderDetailsDto> dtos)
    {
        _details.Clear();

        foreach (var dto in dtos)
        {
            AddOrUpdateDetail(dto); // REGLA ÚNICA (no duplicar código)
        }
    }

    // ===============================
    //   CREAR AGGREGATE DESDE DTO
    // ===============================
    public static OrderAggregate From(CreateOrderDto dto)
    {
        var order = new OrderAggregate
        {
            CustomerId = dto.CustomerId,
            OrderDate = dto.Date,
            InvoiceNumber = dto.InvoiceNumber,
            Total = dto.Total
        };

        if (dto.OrderDetails != null)
        {
            foreach (var d in dto.OrderDetails)
                order.AddOrUpdateDetail(d);
        }

        return order;
    }

    // ===============================
    //    ACTUALIZAR ORDER COMPLETA
    // ===============================
    public void UpdateFrom(CreateOrderDto dto)
    {
        CustomerId = dto.CustomerId;
        OrderDate = dto.Date;
        InvoiceNumber = dto.InvoiceNumber;
        Total = dto.Total;

        // Reemplazar detalles con lógica de sumar duplicados
        ReplaceDetails(dto.OrderDetails);
    }

    // ===============================
    //    CREAR AGGREGATE DESDE ENTITY
    // ===============================
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
