namespace FridaysForks.AsyncApi.Models.V3;

public class Tag
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<ExternalDocumentation> ExternalDocs { get; set; } 
}