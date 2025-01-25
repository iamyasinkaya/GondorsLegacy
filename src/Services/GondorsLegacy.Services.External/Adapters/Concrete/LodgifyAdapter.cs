

using AutoMapper;

namespace GondorsLegacy.Services.External;

public class LodgifyAdapter<T> : ExternalServiceAdapter<T>, IExternalServiceAdapter<T> where T : Property
{
    private readonly ILodgifyApi<T> _lodgifyApi;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="LodgifyAdapter{T}"/> class.
    /// </summary>
    /// <param name="lodgifyApi">An instance of <see cref="ILodgifyApi{T}"/> representing the Lodgify API client.</param>
    /// <param name="mapper">An instance of <see cref="IMapper"/> used to map the API response to the desired domain model.</param>
    public LodgifyAdapter(ILodgifyApi<T> lodgifyApi, IMapper mapper)
    {
        _lodgifyApi = lodgifyApi;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves a list of properties from the Lodgify API.
    /// </summary>
    /// <returns>An <see cref="AdapterResponse{T}"/> containing a list of <see cref="Property"/> objects if successful; otherwise, an error message.</returns>
    /// <remarks>
    /// This method fetches properties with pagination, mapping them using the AutoMapper instance.
    /// It handles exceptions and API response status codes to return appropriate responses.
    /// </remarks>

    public override async Task<AdapterResponse<List<Property>>> GetPropertiesAsync()
    {
        try
        {
            var response = await _lodgifyApi.GetPropertiesAsync(
                includeCount: true,
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
    /// <summary>
    /// Retrieves a specific property from the Lodgify API.
    /// </summary>
    /// <param name="externalPropertyId">The unique identifier of the property to retrieve, as assigned by Lodgify.</param>
    /// <returns>An <see cref="AdapterResponse{T}"/> containing the retrieved <see cref="Property"/> if successful; otherwise, an error message.</returns>
    /// <remarks>
    /// This method fetches a property by its identifier from the Lodgify API, mapping it using the AutoMapper instance.
    /// It handles exceptions and API response status codes to return appropriate responses.
    /// </remarks>
    public override async Task<AdapterResponse<Property>> GetPropertyAsync(string externalPropertyId)
    {
        try
        {
            var response = await _lodgifyApi.GetPropertyAsync(externalPropertyId);

            if (response.IsSuccessStatusCode)
            {

                var mappedData = _mapper.Map<Property>(response?.Content);

                return new AdapterResponse<Property>(true, "Data fetched successfully.", mappedData);
            }

            return new AdapterResponse<Property>(false, $"Failed to fetch data. Status code: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            return new AdapterResponse<Property>(false, $"An error occurred: {ex.Message}");
        }

    }



}
