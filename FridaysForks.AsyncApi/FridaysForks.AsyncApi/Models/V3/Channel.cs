namespace FridaysForks.AsyncApi.Models.V3;

public class Channel
{
    public string Address { get; set; }
    public Dictionary<string, ReferenceOrValue<Message>> Messages { get; set; } 
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public List<Reference<Server>> Servers { get; set; } 
    public Dictionary<string, Parameter> Parameters { get; set; } 
    public List<Tag> Tags { get; set; } 
    public ExternalDocumentation ExternalDocs { get; set; } 
    public ChannelBinding Bindings { get; set; } 
}