using EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1.Models;

namespace EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1.Data.Repositories;

public interface ISubFeature1Repository
{
    void DoSomethingInsert(SubFeature1Model? subFeature1);
}

public class SubFeature1Repository(ILogger<SubFeature1Repository> logger) : ISubFeature1Repository
{
    private readonly ILogger<SubFeature1Repository> _logger = logger;
    public virtual void DoSomethingInsert(SubFeature1Model? subFeature1)
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);
        // Simulate doing something
        _logger.LogInformation("{source} processed message: '{message}'", GetType().FullName, subFeature1?.Message);
    }
}