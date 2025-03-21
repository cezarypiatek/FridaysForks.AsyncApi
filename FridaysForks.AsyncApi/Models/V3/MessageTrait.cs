namespace FridaysForks.AsyncApi.Models.V3;

public class MessageTrait
{
    public ReferenceOrValue<Schema> Headers { get; set; }
    public ReferenceOrValue<CorrelationID> CorrelationId { get; set; }
    public string ContentType { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public List<Tag> Tags { get; set; }
    public ReferenceOrValue<ExternalDocumentation> ExternalDocs { get; set; }
    public ReferenceOrValue<MessageBinding> Bindings { get; set; }
    public List<object> Examples { get; set; }
}