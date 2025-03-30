namespace FridaysForks.AsyncApi.Models.V3;

public class KafkaChannelBinding
{
    public string? Topic { get; set; }
    public int? Partitions { get; set; }
    public int? Replicas { get; set; }
    public KafkaTopicConfiguration? TopicConfiguration { get; set; }
    public string? BindingVersion { get; set; }
}