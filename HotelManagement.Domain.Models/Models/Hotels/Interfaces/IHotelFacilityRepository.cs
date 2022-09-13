using System.Threading.Tasks;
using System;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using System.Collections.Generic;

namespace HotelManagement.Domain.Models.Models.Hotels.Interfaces
{
    public interface IHotelFacilityRepository
    {
        Task<IEnumerable<HotelFacility>> GetAllHotelFacilitiesAsync(Guid hotelId);
        Task<HotelFacility> GetByIdAsync(Guid hotelId, Guid id);
    }
}
