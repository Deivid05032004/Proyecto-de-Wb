// Billing.Sales.FrontEndCode/Models/OrderModels.cs
namespace Billing.Sales.FrontEndCode.Models
{
    // Modelo que usa el formulario (solo para mostrar los campos clave de la orden)
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }

        // Encabezado
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public string InvoiceNumber { get; set; } = "";

        // Campos del cliente (para mostrar en header) - Opción B
        public string CustomerFirstName { get; set; } = "";
        public string CustomerLastName { get; set; } = "";
        public string CustomerIdentificationNumber { get; set; } = "";
        public string CustomerAddress { get; set; } = "";
        public string CustomerEmailAddress { get; set; } = "";
        public string CustomerPhoneNumber { get; set; } = "";
        public string CustomerCity { get; set; } = "";
    }


}
