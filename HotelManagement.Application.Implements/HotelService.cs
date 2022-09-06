using HotelManagement.Application.Interfaces.Hotels;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using System.Threading.Tasks;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using System;

namespace HotelManagement.Application.Implements
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task RegisterHotel(RegisterHotelDto dto)
        {
            var hotel = MapToHotel(dto);

            _hotelRepository.Add(hotel);
        }
        
        public async Task ModifyHotel(Guid id,ModifyHotelDto dto)
        {
            var hotel = MapToHotel(id, dto);

            _hotelRepository.Update(hotel);
        }

        #region PrivateMethods

        private static Hotel MapToHotel(RegisterHotelDto dto)
        {
            var address = new Address(dto.City, dto.AddressDetails);
            var hotel = new Hotel(dto.Name, dto.Stars, address);
            return hotel;
        }

        private static Hotel MapToHotel(Guid id,ModifyHotelDto dto)
        {
            var address = new Address(dto.City, dto.AddressDetails);
            var hotel = new Hotel(id,dto.Name, dto.Stars, address);
            return hotel;
        }


        #endregion
    }
}