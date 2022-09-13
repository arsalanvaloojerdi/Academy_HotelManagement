using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using HotelManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Domain.Models.Models.Hotels.Entities;

namespace HotelManagement.Application.Implements
{
    public class HotelFacilityService : IHotelFacilityService
    {
        private readonly IHotelFacilityRepository _hotelFacilityRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelFacilityService(IHotelFacilityRepository hotelFacilityRepository, IUnitOfWork unitOfWork)
        {
            _hotelFacilityRepository = hotelFacilityRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HotelFacilityDto>> GetAllHotelFacilitiesAsync(Guid hotelId)
        {
            var hotelFacilities = await _hotelFacilityRepository.GetAllHotelFacilitiesAsync(hotelId);

            var hotelFacilitiesDto = hotelFacilities.Select(MapToDto);

            return hotelFacilitiesDto;
        }

        public async Task ModifyHotelFacilityAsync(ModifyHotelFacilityDto dto)
        {
            var hotelFacility = await _hotelFacilityRepository.GetByIdAsync(dto.HotelId, dto.Id);

            hotelFacility.Modify(dto.Name, dto.Description);

            await _unitOfWork.Commit();
        }

        public async Task DisableHotelFacilityAsync(Guid hotelId, Guid id)
        {
            var hotelFacility = await _hotelFacilityRepository.GetByIdAsync(hotelId, id);

            hotelFacility.Disable();

            await _unitOfWork.Commit();
        }


        #region Private methods

        private static HotelFacilityDto MapToDto(HotelFacility hotelFacility)
        {
            return new HotelFacilityDto()
            {
                HotelFacilityId = hotelFacility.Id,
                Name = hotelFacility.Name,
                Description = hotelFacility.Description
            };
        }

        #endregion
    }
}
