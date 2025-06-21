using EC.DIFeatureFolder.Razor.Pages.Feature1.Models;
using EC.DIFeatureFolder.Razor.Pages.Feature1.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EC.DIFeatureFolder.Razor.Pages.Feature1;

public class IndexModel(ILogger<IndexModel> logger, IFeature1Service feature1Service)  : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IFeature1Service _feature1Service = feature1Service;

    public void OnGet()
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);

        // Call the service to do something
        _feature1Service.DoSomething(new Feature1Model { Message = "Hello from Feature1" });
    }
}
