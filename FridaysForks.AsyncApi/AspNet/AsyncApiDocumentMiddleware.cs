using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using FridaysForks.AsyncApi.Converters;
using Microsoft.AspNetCore.Http;

namespace FridaysForks.AsyncApi.AspNet;

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
            var doc = await registry.FindDocument(name);
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
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                        new ReferenceOrValueConverterFactory(),
                        new SchemaReferenceConverter()
                    }
                }));
            }
            return;
        }

        await _next(context);
    }
}