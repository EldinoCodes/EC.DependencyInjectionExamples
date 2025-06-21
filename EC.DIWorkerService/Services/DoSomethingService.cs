using EC.DIWorkerService.Data.Repositories;
using EC.DIWorkerService.Models;

namespace EC.DIWorkerService.Services;

internal interface IDoSomethingService
{
    void DoSomething();
}

internal class DoSomethingService(ILogger<DoSomethingService> logger, IDoSomethingRepository doSomethingRepository) : IDoSomethingService
{
    private readonly ILogger<DoSomethingService> _logger = logger;
    private readonly IDoSomethingRepository _doSomethingRepository = doSomethingRepository;

    public virtual void DoSomething()
    {
        _logger.LogInformation("DoSomethingService is executing.");

        var doSomethingModel = new DoSomethingModel
        {
            Message = "Message send from service to repository"
        };

        _doSomethingRepository.DoSomethingInsert(doSomethingModel);
    }
}
