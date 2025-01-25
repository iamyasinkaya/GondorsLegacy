using Microsoft.AspNetCore.Mvc;

namespace GondorsLegacy.Services.External;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly ExternalServiceFactory _factory;

    /// <summary>
    /// Controller for retrieving properties from external services.
    /// </summary>
    public PropertyController(ExternalServiceFactory factory)
    {
        _factory = factory;
    }

        /// <summary>
        /// Get all properties from a given external service.
        /// </summary>
        /// <param name="externalServiceType">The type of external service to get properties from.</param>
        /// <returns>A list of properties from the external service.</returns>
        /// <response code="200">The list of properties was retrieved successfully.</response>
        /// <response code="400">The external service does not support this operation.</response>
        /// <response code="500">An error occurred while retrieving the list of properties.</response>
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllPropertiesAsync(ExternalType externalServiceType)
    {
        var adapter = _factory.CreateAdapter<Property>(externalServiceType);

        try
        {
            var response = await adapter.GetPropertiesAsync();
            return Ok(response);
        }
        catch (NotImplementedException)
        {
            return BadRequest(new AdapterResponse<Property>(false, $"{externalServiceType} does not support this operation."));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new AdapterResponse<Property>(false, $"An error occurred: {ex.Message}"));
        }
    }

        /// <summary>
        /// Get a property by its id from a given external service.
        /// </summary>
        /// <param name="externalServiceType">The type of external service to get the property from.</param>
        /// <param name="externalPropertyId">The id of the property to retrieve.</param>
        /// <returns>The property from the external service.</returns>
        /// <response code="200">The property was retrieved successfully.</response>
        /// <response code="400">The external service does not support this operation.</response>
        /// <response code="500">An error occurred while retrieving the property.</response>
    [HttpGet("get-by-id/{externalPropertyId}")]
    public async Task<IActionResult> GetPropertyAsync(ExternalType externalServiceType, string externalPropertyId)
    {
        var adapter = _factory.CreateAdapter<Property>(externalServiceType);

        try
        {
            var response = await adapter.GetPropertyAsync(externalPropertyId);
            return Ok(response);
        }
        catch (NotImplementedException ex)
        {
            return BadRequest(new AdapterResponse<Property>(false, ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new AdapterResponse<Property>(false, $"An error occurred: {ex.Message}"));
        }
    }
}

