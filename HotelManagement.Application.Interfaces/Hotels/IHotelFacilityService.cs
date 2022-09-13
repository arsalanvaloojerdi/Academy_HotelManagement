using System;
using HotelManagement.Application.Interfaces.Hotels.Dtos;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HotelManagement.Application.Interfaces.Hotels
{
    public interface IHotelFacilityService
    {
        Task<IEnumerable<HotelFacilityDto>> GetAllHotelFacilitiesAsync(Guid hotelId);

        Task ModifyHotelFacilityAsync(ModifyHotelFacilityDto dto);

        Task DisableHotelFacilityAsync(Guid hotelId, Guid id);
    }
}
