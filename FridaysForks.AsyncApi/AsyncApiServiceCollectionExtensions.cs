using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FridaysForks.AsyncApi;

public static class AsyncApiServiceCollectionExtensions
{
    /// <summary>
    /// Adds AsyncAPI services to the specified <see cref="IServiceCollection"/>.
    /// This method scans the provided assemblies for implementations of <see cref="IAsyncApiDocumentProvider"/> 
    /// and registers them as singletons. It also registers the <see cref="IAsyncApiRegistry"/> as a singleton.
    /// These services are necessary for generating and managing AsyncAPI documents within the application.
    /// </summary>
    public static IServiceCollection AddAsyncApiServices(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
        if (assembliesToScan.Length == 0)
        {
            assembliesToScan = [Assembly.GetCallingAssembly()];
        }
        
        var providerTypes = assembliesToScan
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IAsyncApiDocumentProvider).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false });

        foreach (var type in providerTypes)
        {
            services.AddSingleton(typeof(IAsyncApiDocumentProvider), type);
        }

        services.AddSingleton<IAsyncApiRegistry, AsyncApiRegistry>();

        return services;
    }
}