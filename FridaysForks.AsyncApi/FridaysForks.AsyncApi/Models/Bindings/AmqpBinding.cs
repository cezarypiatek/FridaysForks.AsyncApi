namespace FridaysForks.AsyncApi.Models.Bindings;

public class AmqpBinding:ChannelBinding
{
    public string Is { get; set; }
    public string Exchange { get; set; }
    public string BindingVersion { get; set; } = "latest";
}