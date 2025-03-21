namespace FridaysForks.AsyncApi.Models.V3;

public class Components
{
    public Dictionary<string, Schema>? Schemas { get; set; }
    public Dictionary<string, Server>? Servers { get; set; }
    public Dictionary<string, Channel>? Channels { get; set; }
    public Dictionary<string, Operation>? Operations { get; set; }
    public Dictionary<string, Message>? Messages { get; set; }
    public Dictionary<string, SecurityScheme>? SecuritySchemes { get; set; }
    
    public Dictionary<string, ServerVariable>? ServerVariables { get; set; }
    public Dictionary<string, Parameter>? Parameters { get; set; }
    public Dictionary<string, CorrelationID>? CorrelationIds { get; set; }
    public Dictionary<string, OperationReply>? Replies { get; set; }
    public Dictionary<string, OperationReplyAddress>? ReplyAddresses { get; set; }
    
    public Dictionary<string, ExternalDocumentation>? ExternalDocs { get; set; }
    public Dictionary<string, Tag>? Tags { get; set; }
    public Dictionary<string, OperationTrait>? OperationTraits { get; set; }
    public Dictionary<string, MessageTrait>? MessageTraits { get; set; }
    public Dictionary<string, ServerBinding>? ServerBindings { get; set; }
    public Dictionary<string, ChannelBinding>? ChannelBindings { get; set; }
    public Dictionary<string, MessageBinding>? MessageBindings { get; set; }
    public Dictionary<string, OperationBinding>? OperationBindings { get; set; }
}