using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FridaysForks.AsyncApi;

public static class AsyncApiServiceCollectionExtensions
{
    public static IServiceCollection AddAsyncApi(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
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