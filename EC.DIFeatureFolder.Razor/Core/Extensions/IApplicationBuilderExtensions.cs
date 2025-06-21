using EC.DIFeatureFolder.Razor.Core.Abstractions;

namespace EC.DIFeatureFolder.Razor.Core.Extensions;

public static class IApplicationBuilderExtensions
{
    public static IApplicationBuilder AddApplicationStartups(this IApplicationBuilder applicationBuilder)
    {
        var startupType = typeof(IAppStartup);
        var startupTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && startupType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
        
        foreach (var type in startupTypes)
        {
            var method = type.GetMethod("ConfigureApplication", [typeof(IApplicationBuilder)]);
            if (method is null) continue;

            var startup = (IAppStartup?)Activator.CreateInstance(type);
            if (startup is null) continue;

            applicationBuilder = (IApplicationBuilder?)method.Invoke(startup, [applicationBuilder]) ?? applicationBuilder;
        }

        return applicationBuilder;
    }
}
