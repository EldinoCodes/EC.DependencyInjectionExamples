using EC.DIFeatureFolder.Razor.Pages.Feature1.Data.Repositories;
using EC.DIFeatureFolder.Razor.Pages.Feature1.Models;

namespace EC.DIFeatureFolder.Razor.Pages.Feature1.Services;

public interface IFeature1Service
{
    void DoSomething(Feature1Model? feature1);
}

public class Feature1Service(ILogger<Feature1Service> logger, IFeature1Repository feature1Repository) : IFeature1Service
{
    private readonly ILogger<Feature1Service> _logger = logger;
    private readonly IFeature1Repository _feature1Repository = feature1Repository;
    public virtual void DoSomething(Feature1Model? feature1)
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);
        // do business logic here ???

        // add the data to the repository
        _feature1Repository.DoSomethingInsert(feature1);
    }
}
