namespace FridaysForks.AsyncApi.Models;

public class Message
{
    public string Name { get; set; }
    public string Title { get; set; }
    public object Payload { get; set; }
    public Dictionary<string, object> Bindings { get; set; } = new();
}