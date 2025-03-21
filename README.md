# FridaysForks.AsyncApi
Generate and serve AsyncAPI 3.0 documentation in your ASP.NET Core app

Generate and serve [AsyncAPI 3.0](https://www.asyncapi.com/docs/reference/specification/v3.0.0) documentation in your ASP.NET Core application — similar to how Swagger/Swashbuckle works for REST APIs.

✅ Supports custom bindings (Kafka, AMQP, etc.)  
✅ Supports multiple AsyncAPI documents  
✅ Ships with built-in UI powered by [asyncapi-react](https://github.com/asyncapi/asyncapi-react)

---

## 🚀 Features

- Define AsyncAPI documents using C# POCO classes
- Serialize to JSON or YAML
- Serve specification documents over HTTP
- Visualize AsyncAPI specs in a browser with a customizable UI
- Register and expose multiple AsyncAPI specs

---



## 🧠 Usage

### Register a Document

In `Program.cs`, register your document using `IAsyncApiRegistry`:

```csharp
registry.AddDocument("kafka-example", new AsyncApiDocument
{
    Info = new Info { Title = "Kafka Events", Version = "1.0.0" },
    Channels = new Dictionary<string, Channel>
    {
        ["my-topic"] = new Channel
        {
            Publish = new Operation
            {
                OperationId = "publishEvent",
                Message = new Message
                {
                    Name = "MyKafkaEvent",
                    Payload = new { type = "object", properties = new { id = new { type = "string" } } },
                    Bindings = new Dictionary<string, object>
                    {
                        ["kafka"] = new KafkaBinding { GroupId = "my-group", ClientId = "service-a" }
                    }
                }
            }
        }
    }
});
```

### Add Middleware

```csharp
app.UseMiddleware<AsyncApiDocumentMiddleware>();
app.UseMiddleware<AsyncApiUIMiddleware>();
```

---

## 🌐 Endpoints

- `GET /asyncapi/{name}.json` – JSON version of the document
- `GET /asyncapi/{name}.yaml` – YAML version of the document
- `GET /asyncapi/{name}` – UI rendering of the document using standalone version of `@asyncapi/react-component`:

---
