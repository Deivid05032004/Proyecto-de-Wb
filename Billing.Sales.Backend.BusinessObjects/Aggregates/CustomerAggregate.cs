
namespace Billing.Sales.Backend.BusinessObjects.Aggregates
{
    public class CustomerAggregate : Customer
    {
        public static CustomerAggregate From(CreateCustomerDto customerDto)
        {
            CustomerAggregate customerAggregate = new()
            {
                IdentificationNumber = customerDto.IdentificationNumber,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Address = customerDto.Address,
                EmailAddress = customerDto.EmailAddress,
                PhoneNumber = customerDto.PhoneNumber,
                City = customerDto.City
            };
            return customerAggregate;
        }
        public void UpdateFrom(CreateCustomerDto customerDto)
        {
            IdentificationNumber = customerDto.IdentificationNumber;
            FirstName = customerDto.FirstName;
            LastName = customerDto.LastName;
            Address = customerDto.Address;
            EmailAddress = customerDto.EmailAddress;
            PhoneNumber = customerDto.PhoneNumber;
            City = customerDto.City;
        }
        public static CustomerAggregate FromEntity(Customer entity)
        {
            return new CustomerAggregate
            {
                Id = entity.Id,
                IdentificationNumber = entity.IdentificationNumber,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                EmailAddress = entity.EmailAddress,
                PhoneNumber = entity.PhoneNumber,
                City = entity.City
            };
        }
    }
}
