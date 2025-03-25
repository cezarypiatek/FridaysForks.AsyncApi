namespace FridaysForks.AsyncApi.Models;

public class Components
{
    public Dictionary<string, object> Messages { get; set; } = new();
    public Dictionary<string, object> Schemas { get; set; } = new();
}