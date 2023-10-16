using GondorsLegacy.Services.Reservation.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GondorsLegacy.Services.Reservation.Controllers;

[Produces("application/json")]
[Route("api/v1/[controller]")]
[ApiVersion("1.0")]
[ApiController]
public class ReservationController : ControllerBase
{
    

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReservationCreateDto reservationCreateDto)
    {
        //// Verileri Redis önbelleğine ekleyin
        //var redisKey = "reservation:" + reservationCreateDto;
        //var redisData = JsonConvert.SerializeObject(reservationCreateDto);

        //// StackExchange.Redis ile Redis önbelleğine veriyi ekleyin
        //var cacheService = _serviceProvider.GetRequiredService<ICacheService>(); // Önceki örnekte tanımlanan ICacheService
        //cacheService.SetCachedData(redisKey, redisData, TimeSpan.FromMinutes(15));

        return Ok();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(ReservationUpdateDto reservationUpdateDto)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete()
    {
        return Ok();
    }

    [HttpPost("cancel/{id}")]
    public async Task<IActionResult> Cancel(ReservationCancelDto reservationCancelDto)
    {
        return Ok();
    }
    
}