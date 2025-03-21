namespace FridaysForks.AsyncApi.Models.V3;

public class Server
{
    public string Host { get; set; }
    public string Protocol { get; set; }
    public string ProtocolVersion { get; set; }
    public string Pathname { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public Dictionary<string, ServerVariable> Variables { get; set; } 
    public List<Reference<SecurityScheme>> Security { get; set; } 
    public List<Tag> Tags { get; set; }
    public List<ExternalDocumentation> ExternalDocs { get; set; }
    public ServerBinding Bindings { get; set; } 
}