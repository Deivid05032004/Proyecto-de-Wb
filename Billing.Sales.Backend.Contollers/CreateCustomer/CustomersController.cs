
using Billing.Sales.Entities.Dtos.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Billing.Sales.Backend.Controllers.CreateCustomer;

public static class CustomersController
{
    public static WebApplication UseCustomersController(this WebApplication app)
    {
        app.MapPost(EndPoints.Customers, CreateCustomer);
        app.MapGet(EndPoints.Customers, GetAllCustomers);
        app.MapGet(EndPoints.CustomersById, GetCustomerById);
        app.MapPut(EndPoints.CustomersById, UpdateCustomer);
        app.MapDelete(EndPoints.CustomersById, DeleteCustomer);

        return app;
    }

    // POST: /api/customers
    private static async Task<int> CreateCustomer(
        [FromBody] CreateCustomerDto dto,
        [FromServices] ICustomerInputPort inputPort,
        [FromServices] ICustomerOuputPort outputPort)
    {
        await inputPort.HandleCreateCustomer(dto);
        return outputPort.CustomerById!.Id;
    }

    // GET: /api/customers
    private static async Task<IEnumerable<object>> GetAllCustomers(
        [FromServices] ICustomerInputPort inputPort,
        [FromServices] ICustomerOuputPort outputPort)
    {
        await inputPort.HandleGetAllCustomers();

        return outputPort.CustomersList.Select(c => new
        {
            c.Id,
            c.IdentificationNumber,
            c.FirstName,
            c.LastName,
            c.Address,
            c.EmailAddress,
            c.PhoneNumber,
            c.City
        });
    }

    // GET: /api/customers/{id}
    private static async Task<object?> GetCustomerById(
        [FromRoute] int id,
        [FromServices] ICustomerInputPort inputPort,
        [FromServices] ICustomerOuputPort outputPort)
    {
        await inputPort.HandleGetCustomerById(id);

        if (outputPort.CustomerById is null)
            return null;

        return new
        {
            outputPort.CustomerById.Id,
            outputPort.CustomerById.IdentificationNumber,
            outputPort.CustomerById.FirstName,
            outputPort.CustomerById.LastName,
            outputPort.CustomerById.EmailAddress,
            outputPort.CustomerById.PhoneNumber,
            outputPort.CustomerById.Address,
            outputPort.CustomerById.City
        };
    }

    // PUT: /api/customers/{id}
    private static async Task<bool> UpdateCustomer(
        [FromRoute] int id,
        [FromBody] CreateCustomerDto dto,
        [FromServices] ICustomerInputPort inputPort,
        [FromServices] ICustomerOuputPort outputPort)
    {
        await inputPort.HandleUpdateCustomer(id, dto);
        return true;
    }

    // DELETE: /api/customers/{id}
    private static async Task<bool> DeleteCustomer(
        [FromRoute] int id,
        [FromServices] ICustomerInputPort inputPort,
        [FromServices] ICustomerOuputPort outputPort)
    {
        await inputPort.HandleDeleteCustomer(id);
        return true;
    }
}
