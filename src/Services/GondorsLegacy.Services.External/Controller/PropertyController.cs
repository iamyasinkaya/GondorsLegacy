using Microsoft.AspNetCore.Mvc;

namespace GondorsLegacy.Services.External;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly ExternalServiceFactory _factory;

    public PropertyController(ExternalServiceFactory factory)
    {
        _factory = factory;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync(ExternalType externalType)
    {
        try
        {
            var adapter = _factory.CreateAdapter<Property>(externalType);

            var response = await adapter.GetPropertiesAsync();
            return Ok(response);
        }
        catch (NotImplementedException)
        {
            return BadRequest(new AdapterResponse<Property>(false, "This adapter does not support execution."));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new AdapterResponse<Property>(false, $"An error occurred: {ex.Message}"));
        }
    }
}

