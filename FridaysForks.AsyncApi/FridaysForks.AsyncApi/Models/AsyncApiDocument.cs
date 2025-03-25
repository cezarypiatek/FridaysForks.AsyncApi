namespace FridaysForks.AsyncApi.Models;

public class AsyncApiDocument
{
    public string Asyncapi { get; set; } = "3.0.0";
    public Info Info { get; set; }
    public Dictionary<string, Channel> Channels { get; set; } = new();
    public Components Components { get; set; } = new();
    public Dictionary<string, object> Extensions { get; set; } = new();
}