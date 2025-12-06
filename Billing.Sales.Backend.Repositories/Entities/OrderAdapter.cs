using Billing.Sales.Backend.BusinessObjects.POCOEntities;
using Billing.Sales.Backend.BusinessObjects.ValueObjects;


namespace Billing.Sales.Backend.Repositories.Entities
{
    public class OrderAdapter
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string InvoiceNumber { get; set; }
        public decimal Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
