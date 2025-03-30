using System.Text.Json;
using System.Text.Json.Serialization;
using FridaysForks.AsyncApi.Models.V3;

namespace FridaysForks.AsyncApi.Converters;

public class ReferenceOrValueConverter<T> : JsonConverter<ReferenceOrValue<T>> where T : class
{
    public override ReferenceOrValue<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // You can implement deserialization logic here if needed
        throw new NotImplementedException("Deserialization is not implemented.");
    }

    public override void Write(Utf8JsonWriter writer, ReferenceOrValue<T> value, JsonSerializerOptions options)
    {
        if (value.Reference is not null)
        {
            JsonSerializer.Serialize(writer, value.Reference, options);
        }
        else
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}