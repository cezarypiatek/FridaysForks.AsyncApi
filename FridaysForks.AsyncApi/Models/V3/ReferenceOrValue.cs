namespace FridaysForks.AsyncApi.Models.V3;

public class ReferenceOrValue<T> where T:class
{
    public Reference<T>? Reference { get; }

    public ReferenceOrValue(Reference<T> reference)
    {
        Reference = reference;
    }

    public ReferenceOrValue(T value)
    {
        Value = value;
    }

    public T? Value { get; }
    
    public static implicit operator ReferenceOrValue<T>(T value) => new ReferenceOrValue<T>(value);
    public static implicit operator ReferenceOrValue<T>(Reference<T> value) => new ReferenceOrValue<T>(value);
}