namespace FridaysForks.AsyncApi.Models.V3;

public class Schema
{
    public string Title { get; set; }
    public string Type { get; set; }
    public List<string> Required { get; set; }
    public decimal? MultipleOf { get; set; }
    public decimal? Maximum { get; set; }
    public bool? ExclusiveMaximum { get; set; }
    public decimal? Minimum { get; set; }
    public bool? ExclusiveMinimum { get; set; }
    public int? MaxLength { get; set; }
    public int? MinLength { get; set; }
    public string Pattern { get; set; }
    public int? MaxItems { get; set; }
    public int? MinItems { get; set; }
    public bool? UniqueItems { get; set; }
    public int? MaxProperties { get; set; }
    public int? MinProperties { get; set; }
    public List<object> Enum { get; set; }
    public object Const { get; set; }
    public List<object> Examples { get; set; }
    public Schema If { get; set; }
    public Schema Then { get; set; }
    public Schema Else { get; set; }
    public bool? ReadOnly { get; set; }
    public bool? WriteOnly { get; set; }
    public Dictionary<string, Schema> Properties { get; set; }
    public Dictionary<string, Schema> PatternProperties { get; set; }
    public object AdditionalProperties { get; set; }
    public object AdditionalItems { get; set; }
    public object Items { get; set; }
    public Schema PropertyNames { get; set; }
    public Schema Contains { get; set; }
    public List<Schema> AllOf { get; set; }
    public List<Schema> OneOf { get; set; }
    public List<Schema> AnyOf { get; set; }
    public Schema Not { get; set; }
    public string Description { get; set; }
    public string Format { get; set; }
    public object Default { get; set; }
}