using System;
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
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);

            hotel.DeleteFacility(dto.Id);

            await _unitOfWork.Commit();
        }
        
        public async Task ModifyHotelFacilityAsync(ModifyHotelFacilityDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);

            hotel.ModifyFacility(dto.Id,dto.Name, dto.description);

            await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<HotelDto>> GetAllHotelFacilitiesAsync(Guid id)
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();

            var hotelsDto = hotels.Select(MapToDto);

            return hotelsDto;
        }

        public async Task AddFacilityAsync(AddFacilityDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);
            var facility = new HotelFacility(dto.Name, dto.Description);

            hotel.AddFacility(facility);

            await _unitOfWork.Commit();
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