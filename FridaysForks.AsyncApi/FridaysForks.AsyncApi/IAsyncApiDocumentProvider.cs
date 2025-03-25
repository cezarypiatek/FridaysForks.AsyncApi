using FridaysForks.AsyncApi.Models;

namespace FridaysForks.AsyncApi;

public interface IAsyncApiDocumentProvider
{
    string Name { get; }
    AsyncApiDocument GenerateDocument();
}