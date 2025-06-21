using EC.DIFeatureFolder.Razor.Pages.Feature2.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EC.DIFeatureFolder.Razor.Pages.Feature2;

public class IndexModel(ILogger<IndexModel> logger, IFeature2Service feature2Service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IFeature2Service _feature2Service = feature2Service;
    public void OnGet()
    {
        _logger.LogInformation("{source} is executing.", GetType().FullName);

        // Call the service to do something
        _feature2Service.DoSomething(new Models.Feature2Model { Message = "Hello from Feature2" });
    }
}
