using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.API;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
        .AddApplicationServices()
        .AddInfrastructureServices(builder.Configuration)
        .AddApiServices();

//Add Services to the container
var app = builder.Build();


// Configure the HTTP request pipeine
app.UseApiServices();

if(app.Environment.IsDevelopment())
{
    await app.InitialDatabaseAsync();
}

app.Run();
