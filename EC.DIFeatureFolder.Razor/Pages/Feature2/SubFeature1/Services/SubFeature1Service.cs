using EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1.Data.Repositories;
using EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1.Models;

namespace EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1.Services;

public interface ISubFeature1Service
{
    void DoSomething(SubFeature1Model? subFeature1);
}

public class SubFeature1Service(ILogger<SubFeature1Service> logger, ISubFeature1Repository subFeature1Repository) : ISubFeature1Service
{
    private readonly ILogger<SubFeature1Service> _logger = logger;
    private readonly ISubFeature1Repository _subFeature1Repository = subFeature1Repository;
    public virtual void DoSomething(SubFeature1Model? subFeature1)
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);
        // do business logic here ???

        // add the data to the repository
        _subFeature1Repository.DoSomethingInsert(subFeature1);
    }
}