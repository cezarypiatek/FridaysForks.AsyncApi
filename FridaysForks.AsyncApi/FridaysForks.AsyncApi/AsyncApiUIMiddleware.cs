using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace FridaysForks.AsyncApi;

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
        var match = Regex.Match(path, @"^/asyncapi/(?<name>[^/]+)$");

        if (match.Success)
        {
            var name = match.Groups["name"].Value;
            var url = $"/asyncapi/{name}.json";

            var html = _htmlTemplate.Replace("{{ASYNCAPI_SPEC_URL}}", url);
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(html);
            return;
        }

        await _next(context);
    }
}