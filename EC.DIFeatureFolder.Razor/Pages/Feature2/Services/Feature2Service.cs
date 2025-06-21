using EC.DIFeatureFolder.Razor.Pages.Feature2.Data.Repositories;
using EC.DIFeatureFolder.Razor.Pages.Feature2.Models;

namespace EC.DIFeatureFolder.Razor.Pages.Feature2.Services;

public interface IFeature2Service
{
    void DoSomething(Feature2Model? subFeature1);
}

public class Feature2Service(ILogger<Feature2Service> logger, IFeature2Repository feature2Repository) : IFeature2Service
{
    private readonly ILogger<Feature2Service> _logger = logger;
    private readonly IFeature2Repository _feature2Repository = feature2Repository;
    public virtual void DoSomething(Feature2Model? subFeature1)
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);
        // do business logic here ???

        // add the data to the repository
        _feature2Repository.DoSomethingInsert(subFeature1);
    }
}