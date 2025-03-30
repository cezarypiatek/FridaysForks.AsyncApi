using FridaysForks.AsyncApi;
using FridaysForks.AsyncApi.Models.V3;

class StreetlightsKafkaApiDocProvider : IAsyncApiDocumentProvider
{
    public string Name => "streetlights";

    public ValueTask<AsyncApiDocument> GenerateDocument()
    {
        return ValueTask.FromResult(new AsyncApiDocument()
        {
            Info = new()
            {
                Title = "Streetlights Kafka API",
                Version = "1.0.0",
                Description = """
                              The Smartylighting Streetlights API allows you to remotely manage the city
                              lights.
                              ### Check out its awesome features:

                              * Turn a specific streetlight on/off 🌃  
                              * Dim a specific streetlight 😎
                              * Receive real-time information about environmental lighting conditions 📈
                              """,
                License = new()
                {
                    Name = "Apache 2.0",
                    Url = "https://www.apache.org/licenses/LICENSE-2.0.html"
                }
            },
            DefaultContentType = "application/json",
            Components = new()
            {
                SecuritySchemes = new()
                {
                    ["saslScram"] = new()
                    {
                        Type = "scramSha256",
                        Description = "Provide your username and password for SASL/SCRAM authentication"
                    },
                    ["certs"] = new()
                    {
                        Type = "X509",
                        Description = "Download the certificate files from service provider"
                    }
                },
                OperationTraits = new ()
                {
                    ["kafka"] = new()
                    {
                        Bindings = new ()
                        {
                            Kafka = new ()
                            {
                                ClientId = new Schema()
                                {
                                    Type = "string",
                                    Enum = ["my-app-id"]
                                }
                            }
                        }
                    }
                }
            },
            Servers = new()
            {
                ["scram-connections"] = new()
                {
                    Host = "test.mykafkacluster.org:18092",
                    Protocol = "kafka-secure",
                    Security = [new("saslScram", fromComponents: true)],
                    Tags = new()
                    {
                        new()
                        {
                            Name = "env:test-scram",
                            Description = """
                                          This environment is meant for running internal tests through
                                                   scramSha256
                                          """
                        },
                        new()
                        {
                            Name = "kind:remote",
                            Description = "This server is a remote server. Not exposed by the application"
                        },
                        new()
                        {
                            Name = "visibility:private",
                            Description = "This resource is private and only available to certain users"
                        }
                    }
                },
                ["mtls-connections"] = new()
                {
                    Host = "test.mykafkacluster.org:28093",
                    Protocol = "kafka-secure",
                    Security = [new("certs", fromComponents: true)],
                    Tags = new()
                    {
                        new()
                        {
                            Name = "env:test-mtls",
                            Description = """
                                          This environment is meant for running internal tests through
                                                   mtls
                                          """
                        },
                        new()
                        {
                            Name = "kind:remote",
                            Description = "This server is a remote server. Not exposed by the application"
                        },
                        new()
                        {
                            Name = "visibility:private",
                            Description = "This resource is private and only available to certain users"
                        }
                    }
                }
            },
            Channels = new()
            {
                ["lightingMeasured"] = new()
                {
                    Address = "smartylighting.streetlights.1.0.event.{streetlightId}.lighting.measured",
                    Description = "The topic on which measured values may be produced and consumed.",
                    Parameters = new()
                    {
                        ["streetlightId"] = new()
                        {
                            Description = "The ID of the streetlight."
                        }
                    },
                    Messages = new()
                    {
                        ["lightMeasured"] = new Message()
                        {
                            Name = "lightMeasured",
                            Title = "Light measured",
                            Summary = "Inform about environmental lighting conditions for a particular streetlight.",
                            ContentType = "application/json",
                        }
                    }
                }
            },
            Operations = new ()
            {
                ["receiveLightMeasurement"] = new Operation()
                {
                    Action = OperationAction.Receive,
                    Channel = new("lightingMeasured"),
                    Summary = """
                              Inform about environmental lighting conditions of a particular
                              streetlight.
                              """,
                    Traits = [new Reference<OperationTrait>("kafka", fromComponents:true)]
                }
            }
        });
    }
}