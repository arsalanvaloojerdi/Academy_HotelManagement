using HotelManagement.Api.Host.SeedWorks;
using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelManagement.Api.Host.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : ApiControllerBase
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
            var hotels = await _hotelService.GetAllHotelsAsync();

            return OkResult(ApiMessages.Ok, hotels);
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

            return OkResult(ApiMessages.Ok, hotel);
        }

        /// <summary>
        /// Register a new hotel
        /// </summary>
        /// <param name="dto">Hotel info</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(RegisterHotelDto dto)
        {
            await _hotelService.RegisterHotelAsync(dto);

            return OkResult(ApiMessages.Ok);
        }

        /// <summary>
        /// Modify hotel information
        /// </summary>
        /// <param name="id">Hotel Id</param>
        /// <param name="dto">Modified Info</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ModifyHotelDto dto)
        {
            dto.Id = id;

            await _hotelService.ModifyHotelAsync(dto);

            return OkResult(ApiMessages.Ok);
        }

        [HttpGet("{id}/pictures")]
        public async Task<IActionResult> GetHotelPictures(Guid id)
        {
            return Ok(await _hotelService.GetHotelFacilitiesAsync(id));
        }

        /// <summary>
        /// add picture for hotel
        /// </summary>
        /// <param name="id">Hotel Id</param>
        /// <param name="dto">Picture Info</param>
        /// <returns></returns>
        [HttpPost("{id}/pictures")]
        public async Task<IActionResult> AddPicture(Guid id, AddPictureDto dto)
        {
            dto.HotelId = id;

            await _hotelService.AddPictureAsync(dto);

            return OkResult(ApiMessages.Ok);
        }

        /// <summary>
        /// get hotel facilities
        /// </summary>
        /// <param name="id">hotel id</param>
        /// <returns></returns>
        [HttpGet("{id}/facilities")]
        public async Task<IActionResult> GetHotelFacility(Guid id)
        {
            return Ok(await _hotelService.GetHotelFacilitiesAsync(id));
        }

        /// <summary>
        /// Add facility for a hotel
        /// </summary>
        /// <param name="id">Hotel Id</param>
        /// <param name="dto">Facility Info</param>
        /// <returns></returns>
        [HttpPost("{id}/facilities")]
        public async Task<IActionResult> AddFacility(Guid id, AddFacilityDto dto)
        {
            dto.HotelId = id;

            await _hotelService.AddFacilityAsync(dto);

            return OkResult(ApiMessages.Ok);
        }

        /// <summary>
        /// update facility for a hotel
        /// </summary>
        /// <param name="id">Hotel Id</param>
        /// <param name="facilityId">facility Id</param>
        /// <param name="dto">Facility Info</param>
        /// <returns></returns>
        [HttpPut("{id}/facilities/{facilityId}")]
        public async Task<IActionResult> UpdateFacility(Guid id,Guid facilityId, ModifyFacilityDto dto)
        {
            dto.HotelId = dto.HotelId;
            dto.Id= facilityId;

            await _hotelService.ModifyFacilityAsync(dto);

            return OkResult(ApiMessages.Ok);
        }

        /// <summary>
        /// delete facility for a hotel
        /// </summary>
        /// <param name="id">Hotel Id</param>
        /// <param name="facilityId">Facility Id</param>
        /// <returns></returns>
        [HttpDelete("{id}/facilities/{facilityId}")]
        public async Task<IActionResult> DeleteFacility(Guid id, Guid facilityId)
        {

            await _hotelService.DeleteFacilityAsync(id, facilityId);

            return OkResult(ApiMessages.Ok);
        }

    }
}