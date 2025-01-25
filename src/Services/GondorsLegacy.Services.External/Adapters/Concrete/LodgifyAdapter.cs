

using AutoMapper;

namespace GondorsLegacy.Services.External;

    public class LodgifyAdapter<T> : ExternalServiceAdapter<T>, IExternalServiceAdapter<T> where T : Property
{
    private readonly ILodgifyApi<T> _lodgifyApi;
    private readonly IMapper _mapper;

    public LodgifyAdapter(ILodgifyApi<T> lodgifyApi, IMapper mapper)
    {
        _lodgifyApi = lodgifyApi;
        _mapper = mapper;
    }

    public override async Task<AdapterResponse<List<Property>>> GetPropertiesAsync()
    {
        try
        {
            var response = await _lodgifyApi.GetPropertiesAsync(
                includeCount: false,
                includeInOut: false,
                page: 1,
                size: 50
            );

            if (response.IsSuccessStatusCode)
            {
                
                var mappedData = _mapper.Map<List<Property>>(response?.Content?.Items);
                
                return new AdapterResponse<List<Property>>(true, "Data fetched successfully.", mappedData);
            }
            else
            {
                return new AdapterResponse<List<Property>>(false, $"Failed to fetch data. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            return new AdapterResponse<List<Property>>(false, $"An error occurred: {ex.Message}");
        }
    }

    
    
    
}
