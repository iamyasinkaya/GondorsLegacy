

namespace GondorsLegacy.Services.External;

public abstract class ExternalServiceAdapter<T> : IExternalServiceAdapter<T>
{
    public virtual Task<AdapterResponse<List<Property>>> GetPropertiesAsync()
    {
        throw new NotImplementedException("GetPropertiesAsync method is not implemented.");
    }

    public virtual Task<AdapterResponse<Property>> GetPropertyAsync(string externalPropertyId)
    {
        throw new NotImplementedException();
    }
}
