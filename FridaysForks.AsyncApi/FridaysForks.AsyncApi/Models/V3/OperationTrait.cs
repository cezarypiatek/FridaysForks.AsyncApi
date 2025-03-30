namespace FridaysForks.AsyncApi.Models.V3;

public class OperationTrait
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public Reference<SecurityScheme> Security { get; set; }
    public List<Tag> Tags { get; set; }
    public ExternalDocumentation ExternalDocs { get; set; }
    public OperationBinding Bindings { get; set; }
}