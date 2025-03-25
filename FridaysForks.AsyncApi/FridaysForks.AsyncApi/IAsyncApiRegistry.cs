using FridaysForks.AsyncApi.Models;

namespace FridaysForks.AsyncApi;

public interface IAsyncApiRegistry
{
    void AddDocument(string name, AsyncApiDocument doc);
    AsyncApiDocument Get(string name);
}