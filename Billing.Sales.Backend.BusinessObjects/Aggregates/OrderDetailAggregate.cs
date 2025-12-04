

using Billing.Sales.Entities.Dtos.CreateBill;

namespace Billing.Sales.Backend.BusinessObjects.Aggregates;

public class OrderDetailAggregate : OrderDetail
{
    public static OrderDetailAggregate From(CreateOrderDetailsDto dto)
    {
        return new OrderDetailAggregate
        {
            ProductId = dto.ProductId,
            UnitPrice = (decimal)dto.SalePrice,
            Quantity = dto.Quantity
        };
    }
    public static OrderDetailAggregate FromEntity(OrderDetail entity)
    {
        return new OrderDetailAggregate
        {
            Id = entity.Id,
            OrderId = entity.OrderId,
            ProductId = entity.ProductId,
            UnitPrice = entity.UnitPrice,
            Quantity = entity.Quantity
        };
    }
    public void UpdateFrom(CreateOrderDetailsDto dto)
    {
        ProductId = dto.ProductId;
        UnitPrice = (decimal)dto.SalePrice;
        Quantity = dto.Quantity;
    }

}
