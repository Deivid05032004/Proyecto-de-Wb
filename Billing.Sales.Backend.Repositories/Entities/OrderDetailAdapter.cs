

using Billing.Sales.Backend.BusinessObjects.POCOEntities;

namespace Billing.Sales.Backend.Repositories.Entities;

public class OrderDetailAdapter
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order  { get; set; }
    public int ProductId { get; set; }
    public ProductAdapter Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
