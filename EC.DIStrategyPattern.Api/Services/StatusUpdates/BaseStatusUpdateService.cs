using EC.DIStrategyPattern.Api.Data.Repositories.StatusUpdates;
using EC.DIStrategyPattern.Api.Models.StatusUpdates;

namespace EC.DIStrategyPattern.Api.Services.StatusUpdates;

public interface IStatusUpdateService
{
    void ProcessStatusUpdate(StatusUpdate? statusUpdate);
}

public abstract class BaseStatusUpdateService(ILogger<BaseStatusUpdateService> logger, IStatusUpdateRepository statusUpdateRepository) : IStatusUpdateService
{
    private readonly ILogger<BaseStatusUpdateService> _logger = logger;
    private readonly IStatusUpdateRepository _statusUpdateRepository = statusUpdateRepository;

    public virtual void ProcessStatusUpdate(StatusUpdate? statusUpdate)
    {
        _logger.LogInformation("{source} processing status update for order '{order}'", GetType().FullName, statusUpdate?.OrderNumber);

        _statusUpdateRepository.StatusUpdateAdd(statusUpdate);
    }
}
