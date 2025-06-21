using EC.DIFeatureFolder.Razor.Core.Abstractions;
using EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1.Data.Repositories;
using EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1.Services;

namespace EC.DIFeatureFolder.Razor.Pages.Feature2.SubFeature1;

public class Startup : IAppStartup
{
    public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ISubFeature1Repository, SubFeature1Repository>();
        services.AddScoped<ISubFeature1Service, SubFeature1Service>();

        return services;
    }
    public IApplicationBuilder ConfigureApplication(IApplicationBuilder app)
    {
        // nothing to do here for Feature2
        return app;
    }
}
