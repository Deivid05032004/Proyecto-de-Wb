

namespace Billing.Sales.Fronend.Business.Objects.Interfaces;

public interface ICustomerGateway
{
    Task<int> createCustomerAsync(CreateCustomerDto customerDto);
    Task updateCustomerAsync(int CustomerId, CreateCustomerDto customerDto);
    Task <IEnumerable<CreateCustomerDto>> GetAllCustomersAsync();
    Task <CreateCustomerDto> GetCustomerByIdAsync(int id);
    Task DeleteCustomerByIdAsync(int id);

}
