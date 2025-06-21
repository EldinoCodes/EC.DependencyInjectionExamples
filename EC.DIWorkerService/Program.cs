using EC.DIWorkerService.Data.Repositories;
using EC.DIWorkerService.Services;

namespace EC.DIWorkerService;

/*
 * singleton: A single instance of the service is created and shared across the application.
 * transient: A new instance of the service is created each time it is requested.
 * scoped: A new instance of the service is created for each request (or scope), and it is 
 * disposed of at the end of the request.
 */

/*
 * in a worker service, if you register a scoped serivce and use them via DI in the singleton
 * worker service, they effectively run as a singleton themselves.  in order to use scoped 
 * services in a worker service, you need to create a scope for them at the transaction level.
 * 
 * in this example, we register scoped services and use them in a singleton worker service.  
 * that worker service has a while loop that runs indefinitely with a 1 second pause.  to
 * adhere to the DI rules, we create a scope for the scoped services at the start of each
 * loop iteration.  this allows us to use the scoped services without violating the DI rules.
 * 
 * all output is written to the console, so you can see the worker service scope in action.
 */

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddScoped<IDoSomethingService, DoSomethingService>();
        builder.Services.AddScoped<IDoSomethingRepository, DoSomethingRepository>();

        builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        host.Run();
    }
}