namespace FridaysForks.AsyncApi.Models.V3;

public class AsyncApiDocument
{
    public string Asyncapi { get; set; } = "3.0.0";
    public string Id { get; set; }
    public Info Info { get; set; }
    public Dictionary<string, Server> Servers { get; set; } 
    public string DefaultContentType { get; set; }
    public Dictionary<string, ReferenceOrValue<Channel>> Channels { get; set; } 
    public Dictionary<string, ReferenceOrValue<Operation>> Operations { get; set; } 
    public Components Components { get; set; } 
    
}