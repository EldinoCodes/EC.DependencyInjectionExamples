using EC.DIFeatureFolder.Razor.Core.Abstractions;
using EC.DIFeatureFolder.Razor.Pages.Feature2.Data.Repositories;
using EC.DIFeatureFolder.Razor.Pages.Feature2.Services;

namespace EC.DIFeatureFolder.Razor.Pages.Feature2;

/*
 * testapp.com/feature1/index
 * testapp.com/feature2/index
 * testapp.com/feature2/SubFeature2/index
 * 
 */
public class Startup : IAppStartup
{
    public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFeature2Repository, Feature2Repository>();
        services.AddScoped<IFeature2Service, Feature2Service>();

        return services;
    }
    public IApplicationBuilder ConfigureApplication(IApplicationBuilder app)
    {
        // nothing to do here for Feature2
        return app;
    }
}
