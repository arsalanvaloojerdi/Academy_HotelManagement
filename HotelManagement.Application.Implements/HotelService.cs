using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Application.Implements
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<HotelDto>> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetAllHotelsAsync();

            var hotelsDto = hotels.Select(MapToDto);

            return hotelsDto;
        }

        public async Task RegisterHotel(RegisterHotelDto dto)
        {
            var hotel = MapToHotel(dto);

            _hotelRepository.Add(hotel);
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

        private static Hotel MapToHotel(RegisterHotelDto dto)
        {
            var address = new Address(dto.City, dto.AddressDetails);
            var hotel = new Hotel(dto.Name, dto.Stars, address);
            return hotel;
        }

        #endregion
    }
}