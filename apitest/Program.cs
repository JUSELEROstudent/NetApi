using apitest.Controllers;
using apitest.Hubs;
using Microsoft.AspNetCore.Http;
using apitest.Hubs;

var MyAllowSpecificOrigins = "https://*";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
var app = builder.Build();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

//app.Use(async (context, next) =>
//{
//    if (context.Request.Path.ToString() == "/api/innerlogin" && context.Request.Method.ToString() == "POST")
//    {
//        await next();
//    }
//    else
//    {
//        var validation = new TokenValidationHandler();
//        var responsefrom = await validation.SendAsync(context);
//        if (responsefrom.Equals(System.Net.HttpStatusCode.OK))
//        {
//            await next.Invoke();
//            //await context.Response.WriteAsync("status code se sale de control");
//        }
//        else
//        {
//            context.Response.HttpContext.Response.StatusCode = 400;
//            //await context.Response.WriteAsync("token noo concuerda ");
//        }
//    }
    
//});

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/ChatHub");
app.Run();
