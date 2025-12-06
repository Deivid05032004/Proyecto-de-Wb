namespace Billing.Sales.FrontEndCode.Models
{
    public class OrderDetailFrontModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string ProductBrand { get; set; } = "";
        public string ProductPresentation { get; set; } = "";

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
