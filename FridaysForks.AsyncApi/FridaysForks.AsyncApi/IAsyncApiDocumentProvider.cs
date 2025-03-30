using FridaysForks.AsyncApi.Models.V3;

namespace FridaysForks.AsyncApi;

public interface IAsyncApiDocumentProvider
{
    string Name { get; }
    ValueTask<AsyncApiDocument> GenerateDocument();
}