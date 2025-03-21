using System.Text.Json;
using System.Text.Json.Serialization;
using FridaysForks.AsyncApi.Models.V3;

namespace FridaysForks.AsyncApi.Converters;

public class ReferenceOrValueConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
            return false;

        return typeToConvert.GetGenericTypeDefinition() == typeof(ReferenceOrValue<>);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var innerType = typeToConvert.GetGenericArguments()[0];
        var converterType = typeof(ReferenceOrValueConverter<>).MakeGenericType(innerType);
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }
}