
namespace Billing.Sales.Entities.Dtos.CreateBill;

public class CreateOrderDetailsDto(int productId, int Quantity, double salePrice, double subTotal)
{
    public int ProductId { get; set; } = productId;
    public int Quantity { get; set; } = Quantity;
    public double SalePrice { get; set; } = salePrice;
    public double SubTotal { get; set; } = subTotal;
}
