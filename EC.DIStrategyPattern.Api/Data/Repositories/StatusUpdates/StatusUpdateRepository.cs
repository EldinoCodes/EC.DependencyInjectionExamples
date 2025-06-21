using EC.DIStrategyPattern.Api.Models.StatusUpdates;

namespace EC.DIStrategyPattern.Api.Data.Repositories.StatusUpdates;

public interface IStatusUpdateRepository
{
    void StatusUpdateAdd(StatusUpdate? statusUpdate);
}

public class StatusUpdateRepository(ILogger<StatusUpdateRepository> logger) : IStatusUpdateRepository
{
    private readonly ILogger<StatusUpdateRepository> _logger = logger;

    public void StatusUpdateAdd(StatusUpdate? statusUpdate)
    {
        if (statusUpdate is null) return;

        _logger.LogInformation("Adding status update for '{order}' to the repository.", statusUpdate?.OrderNumber);
    }
}
