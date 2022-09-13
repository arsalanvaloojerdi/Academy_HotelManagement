using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using HotelManagement.Infrastructure.Persistence;

namespace HotelManagement.Application.Implements
{
    public class HotelFacilityService :IHotelFacilityService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelFacilityService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteFacilityAsync(DeleteFacilityDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.Id);
            var facility = new HotelFacility(dto.Name, dto.Description);

            hotel.DeleteFacility(facility);

            await _unitOfWork.Commit();
        }
        
        public async Task ModifyHotelFacilityAsync(ModifyHotelFacilityDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.Id);

            hotel.ModifyFacility(dto.Name, dto.description);

            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<HotelDto>> GetAllHotelFacilityAsync()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();

            var hotelsDto = hotels.Select(MapToDto);

            return hotelsDto;
        }
        
        private static HotelDto MapToDto(Hotel hotel)
        {
            return new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Stars = hotel.Stars
            };
        }
    }
}