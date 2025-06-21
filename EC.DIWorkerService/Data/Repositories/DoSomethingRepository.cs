using EC.DIWorkerService.Models;

namespace EC.DIWorkerService.Data.Repositories;

internal interface IDoSomethingRepository
{
    void DoSomethingInsert(DoSomethingModel? doSomething);
}

internal class DoSomethingRepository(ILogger<DoSomethingRepository> logger) : IDoSomethingRepository
{
    private readonly ILogger<DoSomethingRepository> _logger = logger;

    public virtual void DoSomethingInsert(DoSomethingModel? doSomething)
    {
        _logger.LogInformation("DoSomethingRepository is executing.");
        // Simulate doing something
        _logger.LogInformation("DoSomethingRepository processed message: '{message}'", doSomething?.Message);
    }
}
