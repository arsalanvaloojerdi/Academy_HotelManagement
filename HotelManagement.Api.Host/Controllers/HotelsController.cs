using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
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

        /// <summary>
        /// Get all available hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _hotelService.GetAllHotels();

            return Ok(hotels);
        }

        /// <summary>
        /// Get Hotel Details
        /// </summary>
        /// <param name="id">Hotel Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var hotel = await _hotelService.GetHotelDetailsAsync(id);

            return Ok(hotel);
        }

        /// <summary>
        /// Register a new hotel
        /// </summary>
        /// <param name="dto">Hotel info</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(RegisterHotelDto dto)
        {
            await _hotelService.RegisterHotel(dto);

            return Ok();
        }
    }
}