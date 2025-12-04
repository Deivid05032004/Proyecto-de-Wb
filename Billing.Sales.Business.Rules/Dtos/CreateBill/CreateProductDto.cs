
namespace Billing.Sales.Entities.Dtos.CreateBill;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Presentation { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}
