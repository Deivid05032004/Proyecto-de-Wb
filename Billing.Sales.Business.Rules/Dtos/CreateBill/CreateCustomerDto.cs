

namespace Billing.Sales.Entities.Dtos.CreateBill;

public class CreateCustomerDto
{
    public string IdentificationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
}
