using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace FridaysForks.AsyncApi;

public class AsyncApiDocumentMiddleware
{
    private readonly RequestDelegate _next;

    public AsyncApiDocumentMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, IAsyncApiRegistry registry)
    {
        var path = context.Request.Path.Value;
        var match = Regex.Match(path, @"^/asyncapi/(?<name>[^/]+)\.(json|yaml)$");

        if (match.Success)
        {
            var name = match.Groups["name"].Value;
            var doc = registry.Get(name);
            if (doc == null)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync("Document not found.");
                return;
            }

            var format = path.EndsWith(".yaml") ? "yaml" : "json";
            context.Response.ContentType = format == "yaml" ? "application/x-yaml" : "application/json";

            if (format == "yaml")
            {
                var serializer = new YamlDotNet.Serialization.Serializer();
                await context.Response.WriteAsync(serializer.Serialize(doc));
            }
            else
            {
                await context.Response.WriteAsync(JsonSerializer.Serialize(doc, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));
            }
            return;
        }

        await _next(context);
    }
}