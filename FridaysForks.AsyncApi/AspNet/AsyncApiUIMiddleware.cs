using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace FridaysForks.AsyncApi.AspNet;

public class AsyncApiUIMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _htmlTemplate;
    private readonly string _scriptContent;
    private readonly string _stylesheetContent;

    public AsyncApiUIMiddleware(RequestDelegate next)
    {
        _next = next;
        var assembly = typeof(AsyncApiUIMiddleware).Assembly;
        _htmlTemplate = LoadEmbeddedContent(assembly, "asyncapi-ui.html");
        _scriptContent = LoadEmbeddedContent(assembly, "index.js");
        _stylesheetContent = LoadEmbeddedContent(assembly, "default.min.css");
        
    }

    private static string LoadEmbeddedContent(Assembly assembly, string filename)
    {
        using var stream = assembly.GetManifestResourceStream($"FridaysForks.AsyncApi.UI.{filename}");;
        if (stream == null)
            throw new InvalidOperationException($"Embedded resource '{filename}' not found.");

        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();
        return content;
    }

    public async Task InvokeAsync(HttpContext context, IAsyncApiRegistry registry)
    {
        var path = context.Request.Path.Value;
        var match = Regex.Match(path, @"^/asyncapi/?(.*?)$");
        if (match.Success)
        {
            if(match.Groups[1].Value == "index.js")
            {
                context.Response.ContentType = "application/javascript";
                await context.Response.WriteAsync(_scriptContent);
                return;
            }
            
            if(match.Groups[1].Value == "default.min.css")
            {
                context.Response.ContentType = "text/css";
                await context.Response.WriteAsync(_stylesheetContent);
                return;
            }
            
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