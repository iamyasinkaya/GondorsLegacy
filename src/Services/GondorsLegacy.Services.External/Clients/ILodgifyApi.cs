using Refit;
using System.Threading.Tasks;

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

    

}
