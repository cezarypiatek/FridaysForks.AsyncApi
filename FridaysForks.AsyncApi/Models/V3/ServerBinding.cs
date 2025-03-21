namespace FridaysForks.AsyncApi.Models.V3;

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