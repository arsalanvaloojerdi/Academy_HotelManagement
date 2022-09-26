using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelManagement.Application.Interfaces.Hotels.Dtos;

namespace HotelManagement.Application.Interfaces.Hotels
{
    public interface IHotelFacilityService
    {
        Task AddFacilityAsync(AddFacilityDto dto);

        Task DeleteFacilityAsync(DeleteFacilityDto dto);

        Task ModifyHotelFacilityAsync(ModifyHotelFacilityDto dto);
        
        Task<IEnumerable<HotelDto>> GetAllHotelFacilitiesAsync(Guid id);

    }
}