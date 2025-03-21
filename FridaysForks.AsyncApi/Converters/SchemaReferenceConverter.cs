using System.Text.Json;
using System.Text.Json.Serialization;
using FridaysForks.AsyncApi.Models.V3;

namespace FridaysForks.AsyncApi.Converters;

class SchemaReferenceConverter: JsonConverter<SchemaReference>
{
    public override SchemaReference? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, SchemaReference value, JsonSerializerOptions options)
    {
        if (value.Reference is not null)
        {
            JsonSerializer.Serialize(writer, value.Reference, options);
        }
        else if (value.MultiFormatSchema is not null)
        {
            JsonSerializer.Serialize(writer, value.MultiFormatSchema, options);
        }else if (value.Schema is not null)
        {
            JsonSerializer.Serialize(writer, value.Schema, options);
        }
    }
}