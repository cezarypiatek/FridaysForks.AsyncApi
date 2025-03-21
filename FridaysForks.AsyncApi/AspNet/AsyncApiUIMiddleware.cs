using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace FridaysForks.AsyncApi.AspNet;

public class AsyncApiUIMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _htmlTemplate;

    public AsyncApiUIMiddleware(RequestDelegate next)
    {
        _next = next;
        var assembly = typeof(AsyncApiUIMiddleware).Assembly;
        using var stream = assembly.GetManifestResourceStream("FridaysForks.AsyncApi.UI.asyncapi-ui.html");
        if (stream == null)
            throw new InvalidOperationException("Embedded resource 'asyncapi-ui.html' not found.");

        using var reader = new StreamReader(stream);
        _htmlTemplate = reader.ReadToEnd();
    }

    public async Task InvokeAsync(HttpContext context, IAsyncApiRegistry registry)
    {
        var path = context.Request.Path.Value;
        var match = Regex.Match(path, @"^/asyncapi/?$");

        if (match.Success)
        {
            var allNames = await registry.GetAvailableNames();
            var allDocs = allNames.Select(x => new
            {
                name = x,
                url = $"/asyncapi/{x}.json"
            }).ToArray();

            var html = _htmlTemplate.Replace("DOCUMENT_LIST_SERIALIZED", JsonSerializer.Serialize(allDocs));
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(html);
            return;
        }

        await _next(context);
    }
}