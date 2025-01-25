using System.Collections.Generic;
using System.Threading.Tasks;

namespace GondorsLegacy.Services.External
{
    public abstract class ExternalServiceAdapter<T> : IExternalServiceAdapter<T>
    {
        public virtual Task<AdapterResponse<List<Property>>> GetPropertiesAsync()
        {
            throw new NotImplementedException("GetPropertiesAsync method is not implemented.");
        }

        
    }
}