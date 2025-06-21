namespace EC.DIFeatureFolder.Razor.Core.Abstractions;

public interface IAppStartup
{
    public IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration);
    public IApplicationBuilder ConfigureApplication(IApplicationBuilder app);
}
