using FridaysForks.AsyncApi.Models.V3;

namespace FridaysForks.AsyncApi;

/// <summary>
/// Defines a provider for generating AsyncAPI documents.
/// Implementations of this interface are responsible for creating and providing
/// AsyncAPI documents, which describe the asynchronous APIs available in the application.
/// </summary>
public interface IAsyncApiDocumentProvider
{
    string Name { get; }
    ValueTask<AsyncApiDocument> GenerateDocument();
}