namespace FridaysForks.AsyncApi.Models;

public class Operation
{
    public string OperationId { get; set; }
    public string Summary { get; set; }
    public Message Message { get; set; }
    public Dictionary<string, object> Bindings { get; set; } = new();
}