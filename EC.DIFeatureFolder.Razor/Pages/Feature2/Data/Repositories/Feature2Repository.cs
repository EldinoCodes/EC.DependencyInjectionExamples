using EC.DIFeatureFolder.Razor.Pages.Feature2.Models;

namespace EC.DIFeatureFolder.Razor.Pages.Feature2.Data.Repositories;

public interface IFeature2Repository
{
    void DoSomethingInsert(Feature2Model? subFeature1);
}

public class Feature2Repository(ILogger<Feature2Repository> logger) : IFeature2Repository
{
    private readonly ILogger<Feature2Repository> _logger = logger;
    public virtual void DoSomethingInsert(Feature2Model? feature2)
    {
        _logger.LogInformation("Feature2Repository is executing.");
        // Simulate doing something
        _logger.LogInformation("{source} processed message: '{message}'", GetType().FullName, feature2?.Message);
    }
}