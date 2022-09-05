using HotelManagement.Application.Interfaces.Hotels.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Application.Interfaces.Hotels
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllHotels();

        Task<HotelDetailsDto> GetHotelDetailsAsync(Guid id);

        Task RegisterHotel(RegisterHotelDto dto);
    }
}