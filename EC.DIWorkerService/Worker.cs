using EC.DIWorkerService.Services;

namespace EC.DIWorkerService;

public class Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    private readonly ILogger<Worker> _logger = logger;
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();

            var service = scope.ServiceProvider.GetRequiredService<IDoSomethingService>();
            ArgumentNullException.ThrowIfNull(service, nameof(service));

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            try
            {
                service.DoSomething();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing the service.");
            }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
