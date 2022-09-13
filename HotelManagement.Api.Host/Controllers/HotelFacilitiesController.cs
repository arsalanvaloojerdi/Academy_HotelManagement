using HotelManagement.Api.Host.SeedWorks;
using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelManagement.Api.Host.Controllers
{
    [Route("api/hotels")]
    public class HotelFacilitiesController : ApiControllerBase
    {
        private readonly IHotelFacilityService _hotelFacilityService;

        public HotelFacilitiesController(IHotelFacilityService hotelFacilityService)
        {
            _hotelFacilityService = hotelFacilityService;
        }

        [HttpGet("{hotelId}/facilities")]
        public async Task<IActionResult> GetAll(Guid hotelId)
        {
            var hotelFacilities = await _hotelFacilityService.GetAllHotelFacilitiesAsync(hotelId);

            return OkResult(ApiMessages.Ok, hotelFacilities);
        }

        [HttpPut("{hotelId}/facilities/{id}")]
        public async Task<IActionResult> Put(Guid hotelId, Guid id, ModifyHotelFacilityDto dto)
        {
            dto.HotelId = hotelId;
            dto.Id = id;

            await _hotelFacilityService.ModifyHotelFacilityAsync(dto);

            return OkResult(ApiMessages.Ok);
        }

        [HttpDelete("{hotelId}/facilities/{id}")]
        public async Task<IActionResult> Delete(Guid hotelId, Guid id)
        {
            await _hotelFacilityService.DisableHotelFacilityAsync(hotelId, id);

            return OkResult(ApiMessages.Ok);
        }
    }
}
