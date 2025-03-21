using System.Collections.Concurrent;
using FridaysForks.AsyncApi.Models.V3;

namespace FridaysForks.AsyncApi;

internal class AsyncApiRegistry : IAsyncApiRegistry
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

    public async ValueTask<AsyncApiDocument?> FindDocument(string name)
    {
        if (_docs.TryGetValue(name, out var existingDoc))
        {
            return existingDoc;
        }

        if (_providerMap.TryGetValue(name, out var provider))
        {
            var newDoc = await provider.GenerateDocument();
            _docs[name] = newDoc;
            return newDoc;
        }

        return null;
    }

    public ValueTask<string[]> GetAvailableNames()
    {
        var v1 = _providerMap.Keys.ToArray();
        var v2 = _docs.Keys.ToArray();
        var sum = new HashSet<string>(v1.Concat(v2));
        return new ValueTask<string[]>(sum.ToArray());
    }
}