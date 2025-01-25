using Refit;


namespace GondorsLegacy.Services.External;

public interface ILodgifyApi<T>
{
    [Get("/v2/properties")]
    Task<ApiResponse<LodgifyApiResponse<GetLodgifyPropertyResponse>>> GetPropertiesAsync(
        [Query] bool includeCount,
        [Query] bool includeInOut,
        [Query] int page,
        [Query] int size
    );
    [Get("/v2/properties/{id}")]
    Task<ApiResponse<GetLodgifyPropertyResponse>> GetPropertyAsync([AliasAs("id")] string id);
    
}
