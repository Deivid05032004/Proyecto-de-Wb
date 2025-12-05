using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.Sales.Backend.BusinessObjects.POCOEntities.AuthEntitie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


namespace Billing.Sales.Backend.Contollers.CreateUser;

public static class UserController
{
    public static WebApplication UseUserController(this WebApplication app)
    {
        app.MapPost(EndPoints.Users, CreateUser);
        app.MapGet(EndPoints.UsersById, GetUserById);
        app.MapGet(EndPoints.Users, GetAllUser);
        app.MapDelete(EndPoints.UsersById, DeleteUser);
        app.MapPut(EndPoints.UsersById, UpdateUser);
        return app;
    }
    private static async Task<IEnumerable<User>> GetAllUser(HttpContext context)
    //    [FromServices] IAuthInputPort inputPort
    //    , [FromServices] IAuthOutputPort outputPort
    //    )
    //{
    //    await inputPort.GetAllUsers();
    //    return outputPort.users.Select(u => new
    //    {
    //        u.Id,
    //        u.Email,
    //        u.PasswordHash,
    //        u.IsBlocked,
    //        u.FailedLoginAttempts,
    //        u.BlockedAt
    //    });
    {   throw new NotImplementedException(); }

    

    private static async Task UpdateUser(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task DeleteUser(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task GetUserById(HttpContext context)
    {
        throw new NotImplementedException();
    }

    private static async Task CreateUser(HttpContext context)
    {
        throw new NotImplementedException();
    }
}
