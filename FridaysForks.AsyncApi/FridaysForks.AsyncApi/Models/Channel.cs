namespace FridaysForks.AsyncApi.Models;

public class Channel
{
    public string Description { get; set; }
    public Operation Subscribe { get; set; }
    public Operation Publish { get; set; }
    public Dictionary<string, ChannelBinding> Bindings { get; set; } = new();
}

public abstract class ChannelBinding
{
    
}