using HotelManagement.Application.Interfaces.Hotels.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Application.Interfaces.Hotels
{
    public interface IHotelService
    {
        Task<IEnumerable<HotelDto>> GetAllHotels();

        Task RegisterHotel(RegisterHotelDto dto);
    }
}