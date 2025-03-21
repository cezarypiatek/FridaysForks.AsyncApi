using FridaysForks.AsyncApi.Models.V3;

namespace FridaysForks.AsyncApi;

public interface IAsyncApiRegistry
{
    void AddDocument(string name, AsyncApiDocument doc);
    ValueTask<AsyncApiDocument?> FindDocument(string name);
    ValueTask<string[]> GetAvailableNames();
}