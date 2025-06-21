using EC.DIStrategyPattern.Api.Models.StatusUpdates;
using EC.DIStrategyPattern.Api.Services.StatusUpdates;

namespace EC.DIStrategyPattern.Api.Strategies;

public interface IStatusUpdateServiceStrategy
{
    IStatusUpdateService StatusUpdateServiceGet(StatusUpdate? statusUpdate);
}

public class StatusUpdateServiceStrategy(ILogger<StatusUpdateServiceStrategy> logger, IServiceProvider serviceProvider) : IStatusUpdateServiceStrategy
{
    private readonly ILogger<StatusUpdateServiceStrategy> _logger = logger;
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public IStatusUpdateService StatusUpdateServiceGet(StatusUpdate? statusUpdate)
    {
        var service = _serviceProvider.GetKeyedService<IStatusUpdateService>(statusUpdate?.CustomerId);
            service ??= _serviceProvider.GetKeyedService<IStatusUpdateService>("base");

        ArgumentNullException.ThrowIfNull(service, "No status update service found for customer id: " + statusUpdate?.CustomerId);

        _logger.LogInformation("Using status update service: {service} for status update for : {order}", service.GetType().Name, statusUpdate?.OrderNumber);

        return service;
    }
}
