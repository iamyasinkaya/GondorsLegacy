
namespace GondorsLegacy.Services.External;

public interface IExternalServiceAdapter<T>
{
    Task<AdapterResponse<List<Property>>> GetPropertiesAsync();
    Task<AdapterResponse<Property>> GetPropertyAsync(string externalPropertyId);

}
