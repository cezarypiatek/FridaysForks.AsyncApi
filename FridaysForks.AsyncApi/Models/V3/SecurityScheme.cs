namespace FridaysForks.AsyncApi.Models.V3;

public class SecurityScheme
{
    public string Type { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string In { get; set; }
    public string Scheme { get; set; }
    public string BearerFormat { get; set; }
    public string Flows { get; set; }
    public string OpenIdConnectUrl { get; set; }
    public string[] Scopes { get; set; }
}