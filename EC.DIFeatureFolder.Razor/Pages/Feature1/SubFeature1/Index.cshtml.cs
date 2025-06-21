using EC.DIFeatureFolder.Razor.Pages.Feature1.SubFeature1.Models;
using EC.DIFeatureFolder.Razor.Pages.Feature1.SubFeature1.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EC.DIFeatureFolder.Razor.Pages.Feature1.SubFeature1;

public class IndexModel(ILogger<IndexModel> logger, ISubFeature1Service subFeature1Service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly ISubFeature1Service _subFeature1Service = subFeature1Service;

    public void OnGet()
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);

        // Call the service to do something
        _subFeature1Service.DoSomething(new SubFeature1Model { Message = "Hello from SubFeature1" });

    }
}
