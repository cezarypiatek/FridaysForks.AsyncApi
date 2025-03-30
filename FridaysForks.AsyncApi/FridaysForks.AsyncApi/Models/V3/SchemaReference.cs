namespace FridaysForks.AsyncApi.Models.V3;

public class SchemaReference
{
    public MultiFormatSchema? MultiFormatSchema { get; set; }
    public Schema? Schema { get; set; }
    public Reference<Schema>? Reference { get; set; }
    
    public static implicit operator SchemaReference(MultiFormatSchema value) => new SchemaReference { MultiFormatSchema = value };
    public static implicit operator SchemaReference(Schema value) => new SchemaReference { Schema = value };
    public static implicit operator SchemaReference(Reference<Schema> value) => new SchemaReference { Reference = value };
}