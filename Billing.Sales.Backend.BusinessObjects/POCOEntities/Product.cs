
namespace Billing.Sales.Backend.BusinessObjects.POCOEntities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Presentation { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}
