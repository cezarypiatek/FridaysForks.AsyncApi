using Microsoft.AspNetCore.Builder;

namespace FridaysForks.AsyncApi.AspNet;

public static class AsyncApiMiddlewareExtensions
{
    public static IApplicationBuilder UseAsyncApiDocuments(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AsyncApiDocumentMiddleware>();
    }

    public static IApplicationBuilder UseAsyncApiUI(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AsyncApiUIMiddleware>();
    }

    public static IApplicationBuilder UseAsyncApi(this IApplicationBuilder app)
    {
        return app.UseAsyncApiDocuments()
            .UseAsyncApiUI();
    }
}