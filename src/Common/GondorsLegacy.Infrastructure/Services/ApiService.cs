using GondorsLegacy.CrossCuttingCorners.Services;

namespace GondorsLegacy.Infrastructure.Services;

public class ApiService
{
    private readonly IApiService apiService;

    public ApiService(IApiService apiService)
    {
        this.apiService = apiService;
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        return await apiService.GetAsync<T>(endpoint);
    }

    public async Task<T> PostAsync<T>(string endpoint, object data)
    {
        return await apiService.PostAsync<T>(endpoint, data);
    }

    public async Task<T> PutAsync<T>(string endpoint, object data)
    {
        return await apiService.PutAsync<T>(endpoint, data);
    }

    public async Task DeleteAsync(string endpoint)
    {
        await apiService.DeleteAsync(endpoint);
    }

    public async Task<IEnumerable<T>> GetListAsync<T>(string endpoint)
    {
        return await apiService.GetListAsync<T>(endpoint);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        return await apiService.PostAsync<TRequest, TResponse>(endpoint, data);
    }

    public async Task<TResponse> PutAsync<TRequest, TResponse>(string endpoint, TRequest data)
    {
        return await apiService.PutAsync<TRequest, TResponse>(endpoint, data);
    }
}