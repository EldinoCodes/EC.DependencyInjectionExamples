using EC.DIStrategyPattern.Api.Data.Repositories.StatusUpdates;

namespace EC.DIStrategyPattern.Api.Services.StatusUpdates;

public class StatusUpdateService(ILogger<StatusUpdateService> logger, IStatusUpdateRepository statusUpdateRepository) : BaseStatusUpdateService(logger, statusUpdateRepository)
{
    private readonly ILogger<StatusUpdateService> _logger = logger;
    private readonly IStatusUpdateRepository _statusUpdateRepository = statusUpdateRepository;
}