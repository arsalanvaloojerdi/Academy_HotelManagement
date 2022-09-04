using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelManagement.Api.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RegisterHotelDto dto)
        {
            await _hotelService.RegisterHotel(dto);

            return Ok();
        }
    }
}