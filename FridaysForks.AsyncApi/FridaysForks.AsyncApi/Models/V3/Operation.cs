namespace FridaysForks.AsyncApi.Models.V3;

public class Operation
{
    public OperationAction Action { get; set; }
    public Reference<Channel> Channel { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public ReferenceOrValue<SecurityScheme> Security { get; set; }
    public List<Tag>Tags { get; set; } 
    public ReferenceOrValue<ExternalDocumentation> ExternalDocs { get; set; }
    public ReferenceOrValue<OperationBinding> Bindings { get; set; }
    public List<ReferenceOrValue<OperationTrait>> Traits { get; set; }
    public List<Reference<Message>> Messages { get; set; }
    public ReferenceOrValue<OperationReply> Reply { get; set; }
    
}