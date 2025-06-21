using EC.DIStrategyPattern.Api.Data.Repositories.Orders;
using EC.DIStrategyPattern.Api.Data.Repositories.StatusUpdates;
using EC.DIStrategyPattern.Api.Services.Orders;
using EC.DIStrategyPattern.Api.Services.StatusUpdates;
using EC.DIStrategyPattern.Api.Strategies;

namespace EC.DIStrategyPattern.Api;
/*
 * this project demonstrates the use of a strategy pattern in a .NET 8 web API application.
 * there are two flavors of the strategy pattern used in this project: IEnumerable and keyed.
 * order service strategy is an IEnumerable strategy, where all services are registered by interface
 * and injected into the service strategy and looped over to find the correct service.
 * status update service strategy is a keyed strategy, where each service is registered with a key
 * and then the key is used to select the correct service.  the key is not found, the base service is used.
 * 
 * all output is written to the console, so you can see the strategy pattern in action.
 */
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        /* orders */
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        // register all by interface, so that we can use the strategy pattern to select the correct service based on the order's customer id
        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IOrderService, Customer1OrderService>();
        builder.Services.AddScoped<IOrderService, Customer2OrderService>();
        builder.Services.AddScoped<IOrderServiceStrategy, OrderServiceStrategy>();

        /* status updates */
        builder.Services.AddScoped<IStatusUpdateRepository, StatusUpdateRepository>();
        // register all by interface, so that we can use the strategy pattern to select the correct service based on the status update's customer id
        builder.Services.AddKeyedScoped<IStatusUpdateService, Customer1StatusUpdateService>("customer1");
        builder.Services.AddKeyedScoped<IStatusUpdateService, Customer2StatusUpdateService>("customer2");
        builder.Services.AddKeyedScoped<IStatusUpdateService, StatusUpdateService>("base");
        builder.Services.AddScoped<IStatusUpdateServiceStrategy, StatusUpdateServiceStrategy>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
