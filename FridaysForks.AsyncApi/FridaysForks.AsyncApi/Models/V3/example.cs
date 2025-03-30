using System.Security.Authentication.ExtendedProtection;
using System.Text.Json.Serialization;

namespace FridaysForks.AsyncApi.Models.V3;

public class AsyncApiDocument
{
    public string Asyncapi { get; set; } = "3.0.0";
    public string Id { get; set; }
    public Info Info { get; set; }
    public Dictionary<string, Server> Servers { get; set; } 
    public string DefaultContentType { get; set; }
    public Dictionary<string, Channel> Channels { get; set; } 
    public Dictionary<string, ReferenceOrValue<Operation>> Operations { get; set; } 
    public Components Components { get; set; } 
    
}

public class Info
{
    public string Title { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
    public string TermsOfService { get; set; }
    public Contact Contact { get; set; }
    public License License { get; set; }
    public List<Tag> Tags { get; set; } 
    public List<ExternalDocumentation> ExternalDocs { get; set; }
}

public class Tag
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<ExternalDocumentation> ExternalDocs { get; set; } 
}

public class ExternalDocumentation
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class Contact
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string Email { get; set; }
}

public class License
{
    public string Name { get; set; }
    public string Url { get; set; }
}

public class ReferenceOrValue<T> where T:class
{
    public Reference<T>? Reference { get; }

    public ReferenceOrValue(Reference<T> reference)
    {
        Reference = reference;
    }

    public ReferenceOrValue(T value)
    {
        Value = value;
    }

    public T? Value { get; }
    
    public static implicit operator ReferenceOrValue<T>(T value) => new ReferenceOrValue<T>(value);
    public static implicit operator ReferenceOrValue<T>(Reference<T> value) => new ReferenceOrValue<T>(value);
}

public class Reference<T>(string name, bool fromComponents = false)
{
    [JsonPropertyName("$ref")]
    public string Ref { get;  } = fromComponents ? 
        $"#/components/{char.ToLower(typeof(T).Name[0])}{typeof(T).Name.Substring(1)}s/{name}" 
        : $"#/{char.ToLower(typeof(T).Name[0])}{typeof(T).Name.Substring(1)}s/{name}";
}

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

public class ServerBinding
{
    public object Http { get; set; }
    public object Ws { get; set; }
    public KafkaServerBinding Kafka { get; set; }
    public object Anypointmq { get; set; }
    public object Amqp { get; set; }
    public object Amqp1 { get; set; }
    public object Mqtt { get; set; }
    public object Mqtt5 { get; set; }
    public object Nats { get; set; }
    public object Jms { get; set; }
    public object Sns { get; set; }
    public object Solace { get; set; }
    public object Sqs { get; set; }
    public object Stomp { get; set; }
    public object Redis { get; set; }
    public object Mercure { get; set; }
    public object Ibmmq { get; set; }
    public object Googlepubsub { get; set; }
    public object Pulsar { get; set; }
}

public class KafkaServerBinding
{
    public string SchemaRegistryUrl { get; set; }
    public string SchemaRegistryVendor { get; set; }
    public string BindingVersion { get; set; }
}

public class SecurityScheme
{
    public string Type { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string In { get; set; }
    public string Scheme { get; set; }
    public string BearerFormat { get; set; }
    public string Flows { get; set; }
    public string OpenIdConnectUrl { get; set; }
    public string[] Scopes { get; set; }
}

public class ServerVariable
{
    public string[] Enum { get; set; }
    public string Default { get; set; }
    public string Description { get; set; }
    public string[] Examples { get; set; }
}

public class Channel
{
    public string Address { get; set; }
    public Dictionary<string, Message> Messages { get; set; } 
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public List<Reference<Server>> Servers { get; set; } 
    public Dictionary<string, Parameter> Parameters { get; set; } 
    public List<Tag> Tags { get; set; } 
    public List<ExternalDocumentation> ExternalDocs { get; set; } 
    public ChannelBinding Bindings { get; set; } 
}

public class ChannelBinding
{
    public object Http { get; set; }
    public object Ws { get; set; }
    public KafkaChannelBinding Kafka { get; set; }
    public object Anypointmq { get; set; }
    public object Amqp { get; set; }
    public object Amqp1 { get; set; }
    public object Mqtt { get; set; }
    public object Mqtt5 { get; set; }
    public object Nats { get; set; }
    public object Jms { get; set; }
    public object Sns { get; set; }
    public object Solace { get; set; }
    public object Sqs { get; set; }
    public object Stomp { get; set; }
    public object Redis { get; set; }
    public object Mercure { get; set; }
    public object Ibmmq { get; set; }
    public object Googlepubsub { get; set; }
    public object Pulsar { get; set; }
}

public class KafkaChannelBinding
{
    public string? Topic { get; set; }
    public int? Partitions { get; set; }
    public int? Replicas { get; set; }
    public KafkaTopicConfiguration? TopicConfiguration { get; set; }
    public string? BindingVersion { get; set; }
}

public class KafkaTopicConfiguration
{

    [JsonPropertyName("cleanup.policy")]
    public string[] CleanupPolicy { get; set; }

    [JsonPropertyName("retention.ms")]
    public long? RetentionMs { get; set; }

    [JsonPropertyName("retention.bytes")]
    public long? RetentionBytes { get; set; }

    [JsonPropertyName("delete.retention.ms")]
    public long? DeleteRetentionMs { get; set; }

    [JsonPropertyName("max.message.bytes")]
    public int? MaxMessageBytes { get; set; }

    [JsonPropertyName("confluent.key.schema.validation")]
    public bool? ConfluentKeySchemaValidation { get; set; }

    [JsonPropertyName("confluent.key.subject.name.strategy")]
    public string ConfluentKeySubjectNameStrategy { get; set; }

    [JsonPropertyName("confluent.value.schema.validation")]
    public bool? ConfluentValueSchemaValidation { get; set; }

    [JsonPropertyName("confluent.value.subject.name.strategy")]
    public string ConfluentValueSubjectNameStrategy { get; set; }

}

public class Parameter
{
    public string[] Enum { get; set; }
    public string Default { get; set; }
    public string Description { get; set; }
    public string[] Examples { get; set; }
    public string Location { get; set; }
}

public class Operation
{
    public OperationAction Action { get; set; }
    public Reference<Channel> Channel { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public ReferenceOrValue<SecurityScheme> Security { get; set; }
    public List<Tag>Tags { get; set; } 
    public ExternalDocumentation ExternalDocs { get; set; }
    public Dictionary<string, OperationBinding> Bindings { get; set; }
    public List<ReferenceOrValue<OperationTrait>> Traits { get; set; }
    public List<Reference<Message>> Messages { get; set; }
    public OperationReply Reply { get; set; }
    
    //public static implicit operator ReferenceOrValue<Operation>(Operation value) => new ReferenceOrValue<Operation>(value);
}

public class Schema
{
    public string Title { get; set; }
    public string Type { get; set; }
    public List<string> Required { get; set; }
    public decimal? MultipleOf { get; set; }
    public decimal? Maximum { get; set; }
    public bool? ExclusiveMaximum { get; set; }
    public decimal? Minimum { get; set; }
    public bool? ExclusiveMinimum { get; set; }
    public int? MaxLength { get; set; }
    public int? MinLength { get; set; }
    public string Pattern { get; set; }
    public int? MaxItems { get; set; }
    public int? MinItems { get; set; }
    public bool? UniqueItems { get; set; }
    public int? MaxProperties { get; set; }
    public int? MinProperties { get; set; }
    public List<object> Enum { get; set; }
    public object Const { get; set; }
    public List<object> Examples { get; set; }
    public Schema If { get; set; }
    public Schema Then { get; set; }
    public Schema Else { get; set; }
    public bool? ReadOnly { get; set; }
    public bool? WriteOnly { get; set; }
    public Dictionary<string, Schema> Properties { get; set; }
    public Dictionary<string, Schema> PatternProperties { get; set; }
    public object AdditionalProperties { get; set; }
    public object AdditionalItems { get; set; }
    public object Items { get; set; }
    public Schema PropertyNames { get; set; }
    public Schema Contains { get; set; }
    public List<Schema> AllOf { get; set; }
    public List<Schema> OneOf { get; set; }
    public List<Schema> AnyOf { get; set; }
    public Schema Not { get; set; }
    public string Description { get; set; }
    public string Format { get; set; }
    public object Default { get; set; }
}

public class OperationTrait
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public Reference<SecurityScheme> Security { get; set; }
    public List<Tag> Tags { get; set; }
    public ExternalDocumentation ExternalDocs { get; set; }
    public OperationBinding Bindings { get; set; }
}

public class OperationReply
{
    public object Address { get; set; } // Operation Reply Address Object | Reference Object
    public object Channel { get; set; } // Reference Object
    public List<object> Messages { get; set; }  // List of Reference Objects
}

public class OperationBinding
{
    public object Http { get; set; }
    public object Ws { get; set; }
    public KafkaOperationBinding Kafka { get; set; }
    public object Anypointmq { get; set; }
    public object Amqp { get; set; }
    public object Amqp1 { get; set; }
    public object Mqtt { get; set; }
    public object Mqtt5 { get; set; }
    public object Nats { get; set; }
    public object Jms { get; set; }
    public object Sns { get; set; }
    public object Solace { get; set; }
    public object Sqs { get; set; }
    public object Stomp { get; set; }
    public object Redis { get; set; }
    public object Mercure { get; set; }
    public object Ibmmq { get; set; }
    public object Googlepubsub { get; set; }
    public object Pulsar { get; set; }
}

public class KafkaOperationBinding
{
    public ReferenceOrValue<Schema> GroupId { get; set; }
    public ReferenceOrValue<Schema> ClientId { get; set; }
    public string BindingVersion { get; set; }
}

public enum OperationAction
{
    Send,
    Receive
}

public class Message
{
    public Dictionary<string, object> Headers { get; set; } 
    public object Payload { get; set; }
    public CorelationID CorrelationId { get; set; } 
    public string ContentType { get; set; } 
    public string Name { get; set; } 
    public string Title { get; set; } 
    public string Summary { get; set; } 
    public string Description { get; set; } 
    public List<Tag> Tags { get; set; } 
    public ExternalDocumentation ExternalDocs { get; set; } 
    public Dictionary<string, object> Bindings { get; set; } 
    public Dictionary<string, object> Examples { get; set; } 
    public Dictionary<string, object> Traits { get; set; } 
}

public class CorelationID
{
    public string Description { get; set; }
    public string Location { get; set; }
}

public class Components
{
    public Dictionary<string, Server>? Servers { get; set; }
    public Dictionary<string, Channel>? Channels { get; set; }
    public Dictionary<string, SecurityScheme>? SecuritySchemes { get; set; }
    public Dictionary<string, OperationTrait>? OperationTraits { get; set; }
}
