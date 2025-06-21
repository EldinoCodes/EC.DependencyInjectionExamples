using EC.DIFeatureFolder.Razor.Core.Abstractions;

namespace EC.DIFeatureFolder.Razor.Core.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddStartups(this IServiceCollection services, IConfiguration configuration)
    {
        var startupType = typeof(IAppStartup);
        var startupTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && startupType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
        
        foreach (var type in startupTypes)
        {
            var method = type.GetMethod("ConfigureServices", [typeof(IServiceCollection), typeof(IConfiguration)]);
            if (method is null) continue;

            var startup = (IAppStartup?)Activator.CreateInstance(type);
            if (startup is null) continue;

            services = (IServiceCollection?)method.Invoke(startup, [services, configuration]) ?? services;
        }

        return services;
    }
}
