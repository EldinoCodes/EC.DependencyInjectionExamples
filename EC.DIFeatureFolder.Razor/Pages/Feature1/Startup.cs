using EC.DIFeatureFolder.Razor.Core.Abstractions;
using EC.DIFeatureFolder.Razor.Pages.Feature1.Data.Repositories;
using EC.DIFeatureFolder.Razor.Pages.Feature1.Services;

namespace EC.DIFeatureFolder.Razor.Pages.Feature1;

public class Startup : IAppStartup
{
    public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // Register services specific to Feature1
        services.AddScoped<IFeature1Repository, Feature1Repository>();
        services.AddScoped<IFeature1Service, Feature1Service>();

        return services;
    }
    public IApplicationBuilder ConfigureApplication(IApplicationBuilder app)
    {
        // nothing to do here for Feature1
        return app;
    }
}
