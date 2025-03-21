namespace FridaysForks.AsyncApi.Models.V3;

public class KafkaOperationBinding
{
    public ReferenceOrValue<Schema> GroupId { get; set; }
    public ReferenceOrValue<Schema> ClientId { get; set; }
    public string BindingVersion { get; set; }
}