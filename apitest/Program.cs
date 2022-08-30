using apitest.Controllers;

var MyAllowSpecificOrigins = "https://localhost:8080";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();


var app = builder.Build();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
//builder.Services.AddAuthentication(new TokenValidationHandler);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
