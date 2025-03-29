using FridaysForks.AsyncApi;
using FridaysForks.AsyncApi.Models;
using FridaysForks.AsyncApi.Models.V3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//INFO: Add AsyncApi services
builder.Services.AddAsyncApi(typeof(Program).Assembly);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//INFO: Use AsyncApi middlewares
app.UseAsyncApiDocuments();
app.UseAsyncApiUI();

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

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
           
            Channels = new Dictionary<string, Channel>
            {
                ["testChannel"] = new()
                {
                    Address = "proto_Some_Channel_Compacted",
                    Description = "Sample channel",
                    Servers = [new ("test")], 
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
            Operations = new Dictionary<string, Operation>
            {
                ["updateCache"] = new()
                {
                    Action = OperationAction.Receive,
                    Description = "Persis data in Key-Value store and expose it via REST API",
                    Channel = new ("testChannel"),
                }
            }
        });
    }
}