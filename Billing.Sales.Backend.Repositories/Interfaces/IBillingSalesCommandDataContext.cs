namespace Billing.Sales.Backend.Repositories.Interfaces
{
    public interface IBillingSalesCommandDataContext
    {
        // ============================
        // CUSTOMERS
        // ============================
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Customer customer);

        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);


        // ============================
        // PRODUCTS
        // ============================
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);


        // ============================
        // ORDERS
        // ============================
        Task AddOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);

        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);


        // ============================
        // ORDER DETAILS
        // ============================
        Task AddOrderDetailAsync(OrderDetail detail);
        Task UpdateOrderDetailAsync(OrderDetail detail);
        Task DeleteOrderDetailAsync(OrderDetail detail);

        Task<IEnumerable<OrderDetail>> GetAllOrderDetailsAsync();
        Task<OrderDetail?> GetOrderDetailByIdAsync(int id);


        // ============================
        // UNIT OF WORK
        // ============================
        Task SaveChangesAsync();
    }
}
