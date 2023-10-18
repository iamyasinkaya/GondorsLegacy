namespace GondorsLegacy.Infrastructure.Caching;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GondorsLegacy.CrossCuttingCorners.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

public class CacheService : ICache
{
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public void     Add(string key, object item, TimeSpan timeSpan)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = timeSpan
        };
        string itemJson = JsonConvert.SerializeObject(item);
        byte[] itemBytes = Encoding.UTF8.GetBytes(itemJson);
        _distributedCache.Set(key, itemBytes, options);
    }

    public void Add(string key, object item)
    {
        Add(key, item, TimeSpan.MaxValue);
    }

    public bool Contains(string key)
    {
        byte[] cachedBytes = _distributedCache.Get(key);
        return cachedBytes != null;
    }

    public void Remove(string key)
    {
        _distributedCache.Remove(key);
    }

    public void Clear()
    {
        // IDistributedCache, tüm önbellek öğelerini temizlemek için doğrudan bir yöntem sunmuyor, bu nedenle tüm öğeleri tek tek kaldırmamız gerekebilir.
        // Alternatif olarak, çözümünüze özel bir yöntem geliştirebilirsiniz.
    }

    public T Get<T>(string key)
    {
        byte[] cachedBytes = _distributedCache.Get(key);
        if (cachedBytes != null)
        {
            string itemJson = Encoding.UTF8.GetString(cachedBytes);
            return JsonConvert.DeserializeObject<T>(itemJson);
        }
        return default(T);
    }

    public T GetOrAdd<T>(string key, Func<T> valueFactory)
    {
        return GetOrAdd(key, valueFactory, TimeSpan.MaxValue);
    }

    public T GetOrAdd<T>(string key, Func<T> valueFactory, TimeSpan timeSpan)
    {
        T cachedItem = Get<T>(key);
        if (cachedItem != null)
        {
            return cachedItem;
        }

        T value = valueFactory();
        Add(key, value, timeSpan);
        return value;
    }

    public void Set<T>(string key, T item)
    {
        Set(key, item, TimeSpan.MaxValue);
    }

    public void Set<T>(string key, T item, TimeSpan timeSpan)
    {
        Add(key, item, timeSpan);
    }

    public IDictionary<string, object> GetAll(IEnumerable<string> keys)
    {
        var result = new Dictionary<string, object>();
        foreach (var key in keys)
        {
            var cachedItem = Get<object>(key);
            if (cachedItem != null)
            {
                result[key] = cachedItem;
            }
        }
        return result;
    }
}
