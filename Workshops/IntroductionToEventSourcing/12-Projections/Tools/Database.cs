namespace IntroductionToEventSourcing.GettingStateFromEvents.Tools;

public class Database
{
    private readonly Dictionary<Guid, object> storage = new();

    public void Store<T>(Guid id, T obj) where T: class
    {
        if (!storage.ContainsKey(id))
            storage.Add(id, obj);
        else
            storage[id] = obj;
    }

    public T? Get<T>(Guid id) where T: class
    {
        return storage.TryGetValue(id, out var result) ? (T)result : null;
    }
}
