using EC.DIFeatureFolder.Razor.Pages.Feature1.Models;

namespace EC.DIFeatureFolder.Razor.Pages.Feature1.Data.Repositories;

public interface IFeature1Repository
{
    void DoSomethingInsert(Feature1Model? feature1);
}

public class Feature1Repository(ILogger<Feature1Repository> logger) : IFeature1Repository
{
    private readonly ILogger<Feature1Repository> _logger = logger;
    public virtual void DoSomethingInsert(Feature1Model? feature1)
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);
        // Simulate doing something
        _logger.LogInformation("{source} processed message: '{message}'", GetType().FullName, feature1?.Message);
    }
}