namespace FridaysForks.AsyncApi.Models.Bindings;

public class KafkaBinding:ChannelBinding
{
    public string GroupId { get; set; }
    public string ClientId { get; set; }
    public string BindingVersion { get; set; } = "latest";
}