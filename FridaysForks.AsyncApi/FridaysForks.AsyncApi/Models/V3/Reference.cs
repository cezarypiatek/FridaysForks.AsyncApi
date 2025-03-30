using System.Text.Json.Serialization;

namespace FridaysForks.AsyncApi.Models.V3;

public class Reference<T>
{
    //public Reference(string name, bool fromComponents = false)
    // {
    //     Ref = fromComponents ? 
    //         $"#/components/{char.ToLower(typeof(T).Name[0])}{typeof(T).Name.Substring(1)}s/{name}" 
    //         : $"#/{char.ToLower(typeof(T).Name[0])}{typeof(T).Name.Substring(1)}s/{name}";
    // }

    public Reference()
    {
    }

    [JsonPropertyName("$ref")]
    public string Ref { get; set; }


    public static Reference<T> FromComponents(string name)
    {
        var path = $"#/components/{char.ToLower(typeof(T).Name[0])}{typeof(T).Name.Substring(1)}s/{name}";
        return new Reference<T>()
        {
            Ref = path
        };
    }
    public static Reference<T> FromGlobals(string name)
    {
        var path = $"#/{char.ToLower(typeof(T).Name[0])}{typeof(T).Name.Substring(1)}s/{name}";
        return new Reference<T>()
        {
            Ref = path
        };
    }
    
    public static Reference<T> FromPath(string path)
    {
        return new Reference<T>()
        {
            Ref = $"#/{path}"
        };
    }
}