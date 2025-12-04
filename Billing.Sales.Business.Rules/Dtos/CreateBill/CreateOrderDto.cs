
namespace Billing.Sales.Entities.Dtos.CreateBill;

public class CreateOrderDto(int customerId, DateTime date, string invoiceNumber, decimal total,IEnumerable<CreateOrderDetailsDto>orderDetails )
{
    public int CustomerId { get; } = customerId;
    public DateTime Date { get; } = date;
    public string InvoiceNumber { get;} = invoiceNumber;
    public decimal Total { get; } = total;
    public IEnumerable<CreateOrderDetailsDto> OrderDetails { get; } = orderDetails;

}
