namespace FridaysForks.AsyncApi.Models.V3;

public class Parameter
{
    public string[] Enum { get; set; }
    public string Default { get; set; }
    public string Description { get; set; }
    public string[] Examples { get; set; }
    public string Location { get; set; }
}