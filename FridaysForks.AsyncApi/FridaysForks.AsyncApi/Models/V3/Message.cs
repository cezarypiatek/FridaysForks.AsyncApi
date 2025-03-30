namespace FridaysForks.AsyncApi.Models.V3;

public class Message
{
    public Dictionary<string, ReferenceOrValue<Schema>> Headers { get; set; } 
    public SchemaReference Payload { get; set; }
    public CorrelationID CorrelationId { get; set; } 
    public string ContentType { get; set; } 
    public string Name { get; set; } 
    public string Title { get; set; } 
    public string Summary { get; set; } 
    public string Description { get; set; } 
    public List<Tag> Tags { get; set; } 
    public ReferenceOrValue<ExternalDocumentation> ExternalDocs { get; set; } 
    public ReferenceOrValue<MessageBinding> Bindings { get; set; } 
    public Dictionary<string, object> Examples { get; set; } 
    public List<ReferenceOrValue<MessageTrait>> Traits { get; set; } 
}