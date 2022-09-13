using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using HotelManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public async Task AddFacilityAsync(AddFacilityDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);
            var facility = new HotelFacility(dto.Name, dto.Description, dto.HotelId);

            hotel.AddFacility(facility);

            await _unitOfWork.Commit();
        }

        public async Task AddImageAsync(AddHotelImageDto dto)
        {
            var hotel = await _hotelRepository.GetByIdAsync(dto.HotelId);

            hotel.AddImage(dto.Image);

            await _unitOfWork.Commit();
        }

        public async Task<HotelImagesDto> GetImagesAsync(Guid id)
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);

            var hotelImagesDto = MapToImagesDto(hotel);

            return hotelImagesDto;
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

        private static HotelImagesDto MapToImagesDto(Hotel hotel)
        {
            return new HotelImagesDto
            {
                Id = hotel.Id,
                Image = hotel.Images
            };
        }

        private static Hotel MapToHotel(RegisterHotelDto dto)
        {
            var address = new Address(dto.City, dto.AddressDetails);
            var hotel = new Hotel(dto.Name, dto.Stars, address);
            return hotel;
        }

        #endregion
    }
}