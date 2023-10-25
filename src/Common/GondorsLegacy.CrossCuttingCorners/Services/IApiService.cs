using Refit;

namespace GondorsLegacy.CrossCuttingCorners.Services;

public interface IApiService
    {
        // Örnek bir GET metodu
        [Get("/{endpoint}")]
        Task<T> GetAsync<T>(string endpoint);

        // Örnek bir POST metodu
        [Post("/{endpoint}")]
        Task<T> PostAsync<T>(string endpoint, [Body] object data);

        // Örnek bir PUT metodu
        [Put("/{endpoint}")]
        Task<T> PutAsync<T>(string endpoint, [Body] object data);

        // Örnek bir DELETE metodu
        [Delete("/{endpoint}")]
        Task DeleteAsync(string endpoint);

        // Örnek bir GET metodu koleksiyon döndüren
        [Get("/{endpoint}")]
        Task<IEnumerable<T>> GetListAsync<T>(string endpoint);

        // Örnek bir POST metodu
        [Post("/{endpoint}")]
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, [Body] TRequest data);

        // Örnek bir PUT metodu
        [Put("/{endpoint}")]
        Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, [Body] TRequest data);
    }
