using System.Text.Json.Serialization;

namespace FridaysForks.AsyncApi.Models.V3;

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