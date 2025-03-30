using FridaysForks.AsyncApi;
using FridaysForks.AsyncApi.Models.V3;

class SampleAsyncApiDocProvider: IAsyncApiDocumentProvider
{
    public string Name => "test";
    public ValueTask<AsyncApiDocument> GenerateDocument()
    {
        return ValueTask.FromResult(new AsyncApiDocument()
        {
            Info = new()
            {
                Title = "Test",
                Version = "1.0.0"
            },
           
            Channels = new ()
            {
                ["testChannel"] = new Channel()
                {
                    Address = "proto_Some_Channel_Compacted",
                    Description = "Sample channel",
                    Servers = [Reference<Server>.FromGlobals("test")], 
                    Bindings = new ChannelBinding
                    {
                        Kafka = new KafkaChannelBinding
                        {
                            Topic = "proto_Some_Channel_Compacted",
                            Partitions = 4,
                            Replicas = 3,
                            BindingVersion = "0.5.0",
                            TopicConfiguration = new KafkaTopicConfiguration
                            {
                                CleanupPolicy = ["delete", "compact"],
                                RetentionMs = 1001,
                                RetentionBytes = 1002,
                            }
                        }
                    } 
                }
            },
            Servers  = new Dictionary<string, Server>
            {
                ["test"] = new()
                {
                    Host = "localhost",
                    Protocol = "SASL_SSL",
                    Description = "Sample RedPanda server",
                    Bindings = new ServerBinding
                    {
                        Kafka = new KafkaServerBinding
                        {
                            SchemaRegistryUrl = "http://localhost:8081",
                            SchemaRegistryVendor = "confluent",
                            BindingVersion = "0.5.0"
                        }
                    }
                }
            },
            Operations = new ()
            {
                ["updateCache"] = new Operation()
                {
                    Action = OperationAction.Receive,
                    Description = "Persis data in Key-Value store and expose it via REST API",
                    Channel = Reference<Channel>.FromGlobals("testChannel"),
                }
            }
        });
    }
}