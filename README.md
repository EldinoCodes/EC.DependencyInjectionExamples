# EC.DependencyInjectionExamples
Various examples of .Net 8.0 dependency injection usage.  all of these projects output logs to the console to demonstrate each implementation.

## Projects

### EC.DIFeatureFolder.Razor

The Feature Folder project demonstrates the use of a feature folder structure in a .NET 8 Razor Pages application.  The feature folders allow independent modules to register their own services and middleware making them independent from the main application.  This structure allows for a more modular and maintainable codebase while at the same time resulting in some duplication of code across the independent modules.

### EC.DIStrategyPattern.Api

 This Strategy Pattern project demonstrates a basic strategy pattern in a .NET 8 web API application.
 There are two flavors of the strategy pattern used in this project: IEnumerable collection and keyed service provider:
 - `OrderServiceStrategy.cs` uses an IEnumerable collection where all services are registered to a single `IOrderService` interface and all of the registered instances are injected as `IEnumerable<IOrderService>` and looped over based on a order property value to find the correct service.
 - `StatusUpdateServiceStrategy.cs` uses the built in keyed service registration where each service is registered with a key and the `IServiceProvider` is injected and used as a lookup mechanism based on a statusupdate property.
 
 ### EC.DIWorkerService

 This Worker Service project demonstrates the use of a .NET 8 worker service with dependency injection. The worker service is a background service that runs in the background and can be used for long-running tasks. The project uses a simple logging service to demonstrate how to register and use **SCOPED** services in a worker service.