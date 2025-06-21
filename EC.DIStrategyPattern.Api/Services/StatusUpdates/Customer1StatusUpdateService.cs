using EC.DIStrategyPattern.Api.Data.Repositories.StatusUpdates;
using EC.DIStrategyPattern.Api.Models.StatusUpdates;

namespace EC.DIStrategyPattern.Api.Services.StatusUpdates;

public class Customer1StatusUpdateService(ILogger<Customer1StatusUpdateService> logger, IStatusUpdateRepository statusUpdateRepository) : BaseStatusUpdateService(logger, statusUpdateRepository)
{
    private readonly ILogger<Customer1StatusUpdateService> _logger = logger;

    public override void ProcessStatusUpdate(StatusUpdate? statusUpdate)
    {
        _logger.LogInformation("{source} doing custom status update logic for order: {order}", GetType().Name, statusUpdate?.OrderNumber);

        // still call the base implementation as default logic is okay here.
        base.ProcessStatusUpdate(statusUpdate);
    }
}
