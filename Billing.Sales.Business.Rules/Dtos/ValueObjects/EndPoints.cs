

namespace Billing.Sales.Entities.Dtos.ValueObjects;

public class EndPoints
{
    private const string BaseApi = "/api";

    // PRODUCTS
    public const string Products = $"{BaseApi}/products";
    public const string ProductsById = $"{BaseApi}/products/{{id}}";

    // CUSTOMERS
    public const string Customers = $"{BaseApi}/customers";
    public const string CustomersById = $"{BaseApi}/customers/{{id}}";

    // ORDERS
    public const string Orders = $"{BaseApi}/orders";
    public const string OrdersById = $"{BaseApi}/orders/{{id}}";

    // ORDER DETAILS
    public const string OrderDetail = $"{BaseApi}/orderdetail";
    public const string OrderDetailById = $"{BaseApi}/orderdetail/{{id}}";
}
