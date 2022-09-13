using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using HotelManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Application.Implements
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<HotelDto>> GetAllHotelsAsync()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();

            var hotelsDto = hotels.Select(MapToDto);

            return hotelsDto;
        }

        public async Task<HotelDetailsDto> GetHotelDetailsAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            var hotelDetailsDto = MapToDetailsDto(hotel);

            return hotelDetailsDto;
        }

        public async Task<HotelWithFacilityDto> GetHotelFacilitiesAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetHotelWithFacilitiesByIdAsync(id);

            var hotelDetailsDto = MapToHotelWithFacilityDto(hotel);

            return hotelDetailsDto;
        }

        public async Task<HotelWithFacilityDto> GetHotelPicturesAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetHotelWithPicturesByIdAsync(id);

            var hotelDetailsDto = MapToHotelWithFacilityDto(hotel);

            return hotelDetailsDto;
        }


        public async Task RegisterHotelAsync(RegisterHotelDto dto)
        {
            var hotel = MapToHotel(dto);

            _hotelRepository.Add(hotel);

            await _unitOfWork.Commit();
        }

        public async Task ModifyHotelAsync(ModifyHotelDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.Id);

            hotel.Modify(dto.Name, dto.Stars);

            await _unitOfWork.Commit();
        }

        public async Task AddPictureAsync(AddPictureDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);
            var picture = new HotelPicture(dto.Name, dto.FileUrl);

            hotel.AddPictures(picture);

            await _unitOfWork.Commit();
        }

        public async Task AddFacilityAsync(AddFacilityDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);
            var facility = new HotelFacility(dto.Name, dto.Description);

            hotel.AddFacility(facility);

            await _unitOfWork.Commit();
        }

        public async Task ModifyFacilityAsync(ModifyFacilityDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);
            var facility = new HotelFacility(dto.Id,dto.Name, dto.Description);

            hotel.ModifyFacility(facility);

            await _unitOfWork.Commit();
        }
        public async Task DeleteFacilityAsync(Guid hotelId,Guid facilityId)
        {
            var hotel = await _hotelRepository.GetByIdAsync(hotelId);

            hotel.DeleteFacility(facilityId);

            await _unitOfWork.Commit();
        }

        #region PrivateMethods

        private static HotelDto MapToDto(Hotel hotel)
        {
            return new HotelDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Stars = hotel.Stars
            };
        }

        private static HotelDetailsDto MapToDetailsDto(Hotel hotel)
        {
            return new HotelDetailsDto
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Stars = hotel.Stars,
                City = hotel.Address.City,
                Address = hotel.Address.Details
            };
        }

        private static HotelFacilityDto MapToHotelFacilityDto(HotelFacility hotelFacility)
        {
            return new HotelFacilityDto(hotelFacility.Name, hotelFacility.Description);
        }
        private static HotelPictureDto MapToHotelPictureDto(HotelPicture hotelsPicture)
        {
            return new HotelPictureDto(hotelsPicture.Name, hotelsPicture.FileUrl);
        }

        private static Hotel MapToHotel(RegisterHotelDto dto)
        {
            var address = new Address(dto.City, dto.AddressDetails);
            var hotel = new Hotel(dto.Name, dto.Stars, address);
            return hotel;
        }

        private static HotelWithFacilityDto MapToHotelWithFacilityDto(Hotel hotel)
        {
            return new HotelWithFacilityDto(hotel.Facilities.Select(s=>MapToHotelFacilityDto(s)).ToList())
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Stars = hotel.Stars,
            };
        }

        private static HotelWithPictureDto MapToHotelWithPictureDto(Hotel hotel)
        {
            return new HotelWithPictureDto(hotel.Pictures.Select(s => MapToHotelPictureDto(s)).ToList())
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Stars = hotel.Stars,
            };
        }

        #endregion
    }
}