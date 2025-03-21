namespace FridaysForks.AsyncApi.Models.V3;

public class Info
{
    public string Title { get; set; }
    public string Version { get; set; }
    public string Description { get; set; }
    public string TermsOfService { get; set; }
    public Contact Contact { get; set; }
    public License License { get; set; }
    public List<Tag> Tags { get; set; } 
    public List<ExternalDocumentation> ExternalDocs { get; set; }
}