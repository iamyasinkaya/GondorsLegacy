namespace GondorsLegacy.CrossCuttingCorners.Caching;

public interface ICache
{
    void Add(string key, object item, TimeSpan timeSpan);

    void Add(string key, object item);

    bool Contains(string key);

    void Remove(string key);

    void Clear();

    T Get<T>(string key);

    T GetOrAdd<T>(string key, Func<T> valueFactory, TimeSpan timeSpan);

    T GetOrAdd<T>(string key, Func<T> valueFactory);

    void Set<T>(string key, T item, TimeSpan timeSpan);

    void Set<T>(string key, T item);

    IDictionary<string, object> GetAll(IEnumerable<string> keys);
}


