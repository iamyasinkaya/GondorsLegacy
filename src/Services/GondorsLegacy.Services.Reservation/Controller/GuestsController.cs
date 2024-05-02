//using GondorsLegacy.Services.Reservation.Commands.Guest;
//using GondorsLegacy.Services.Reservation.Models.Requests.Guest;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace GondorsLegacy.Services.Reservation.Controller
//{
//    [Route("api/v1/[controller]")]
//    [ApiController]
//    public class GuestsController : ControllerBase
//    {
//        private readonly IMediator _dispatcher;

//        public GuestsController(IMediator dispatcher)
//        {
//            _dispatcher = dispatcher;
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGuestRequest request)
//        {
//            if (ModelState.IsValid)
//            {
//                await _dispatcher.Send(new UpdateGuestCommand { Guest = request.Guest });
//                return Ok(request.Guest.Id);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }
//    }
//}
