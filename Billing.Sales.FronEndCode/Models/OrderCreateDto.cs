using System.Collections.Generic;

namespace Billing.Sales.FrontEndCode.Models
{
    public class OrderCreateDto
    {
        public int CustomerId { get; set; }
        public string InvoiceNumber { get; set; } = "";
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public decimal Total { get; set; }

        public List<OrderDetailCreateDto> OrderDetails { get; set; } = new();
    }
}
