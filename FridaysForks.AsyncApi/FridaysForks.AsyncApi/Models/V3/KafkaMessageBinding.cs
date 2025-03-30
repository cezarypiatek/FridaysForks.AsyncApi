namespace FridaysForks.AsyncApi.Models.V3;

public class KafkaMessageBinding
{
    public ReferenceOrValue<Schema> Key { get; set; }
    public string SchemaIdLocation { get; set; }
    public string SchemaIdPayloadEncoding { get; set; }
    public string SchemaLookupStrategy { get; set; }
    public string BindingVersion { get; set; }
}