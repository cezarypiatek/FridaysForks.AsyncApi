using System.Collections.Concurrent;
using FridaysForks.AsyncApi.Models;

namespace FridaysForks.AsyncApi;

public class AsyncApiRegistry : IAsyncApiRegistry
{
    private readonly ConcurrentDictionary<string, AsyncApiDocument> _docs = new();
    private readonly Dictionary<string, IAsyncApiDocumentProvider> _providerMap;

    public AsyncApiRegistry(IEnumerable<IAsyncApiDocumentProvider> providers)
    {
        _providerMap = providers.ToDictionary(p => p.Name);
    }

    public void AddDocument(string name, AsyncApiDocument doc)
    {
        _docs[name] = doc;
    }

    public AsyncApiDocument Get(string name)
    {
        if (_docs.TryGetValue(name, out var existingDoc))
        {
            return existingDoc;
        }

        if (_providerMap.TryGetValue(name, out var provider))
        {
            var newDoc = provider.GenerateDocument();
            _docs[name] = newDoc;
            return newDoc;
        }

        throw new InvalidOperationException($"ASYNC API Document '{name}' not found.");
    }
}