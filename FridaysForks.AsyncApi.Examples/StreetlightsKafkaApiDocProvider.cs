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
                },
                MessageTraits = new()
                {
                  ["commonHeaders"] = new MessageTrait()
                  {
                      Headers = new Schema()
                      {
                          Type = "object",
                          Properties = new ()
                          {
                              ["my-app-header"] = new Schema()
                              {
                                  Type = "integer",
                                  Minimum = 0,
                                  Maximum = 100
                              }
                          }
                      }
                  }  
                },
                Messages = new ()
                {
                    ["lightMeasured"] = new Message()
                    {
                        Summary = "Inform about environmental lighting conditions of a particular streetlight.",
                        ContentType = "application/json",
                        Payload = new Schema()
                        {
                            Type = "object",
                            Properties = new()
                            {
                                ["lumens"] = new Schema()
                                {
                                    Type = "integer",
                                    Format = "int32",
                                    Minimum = 0,
                                    Description = "Light intensity measured in lumens."
                                },
                                ["sentAt"] = new Schema()
                                {
                                    Type = "string",
                                    Format = "date-time",
                                    Description = "Date and time when the message was sent."
                                }
                            }
                        },
                        Traits = [Reference<MessageTrait>.FromComponents("commonHeaders")]
                    }
                }
            },
            Servers = new()
            {
                ["scram-connections"] = new()
                {
                    Host = "test.mykafkacluster.org:18092",
                    Protocol = "kafka-secure",
                    Security = [Reference<SecurityScheme>.FromComponents("saslScram")],
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
                    Security = [Reference<SecurityScheme>.FromComponents("certs")],
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
                ["lightingMeasured"] = new Channel()
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
                        ["lightMeasured"] = Reference<Message>.FromComponents("lightMeasured")
                    }
                }
            },
            Operations = new ()
            {
                ["receiveLightMeasurement"] = new Operation()
                {
                    Action = OperationAction.Receive,
                    Channel = Reference<Channel>.FromGlobals("lightingMeasured"),
                    Summary = """
                              Inform about environmental lighting conditions of a particular
                              streetlight.
                              """,
                    Traits = [Reference<OperationTrait>.FromComponents("kafka")],
                    Messages = [
                        Reference<Message>.FromPath("channels/lightingMeasured/messages/lightMeasured")
                    ]
                }
            }
        });
    }
}