using System;
using System.Threading.Tasks;
using HotelManagement.Application.Interfaces.Hotels.Dtos;

namespace HotelManagement.Application.Interfaces.Hotels
{
    public interface IHotelService
    {
        Task ModifyHotel(Guid id, ModifyHotelDto dto);
        Task RegisterHotel(RegisterHotelDto dto);
    }
}