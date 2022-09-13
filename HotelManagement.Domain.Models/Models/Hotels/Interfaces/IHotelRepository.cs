using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Domain.Models.Models.Hotels.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();

        Task<Hotel> GetByIdAsync(Guid id);

        void Add(Hotel hotel);
        Task<Hotel> GetHotelWithFacilitiesByIdAsync(Guid id);
        Task<Hotel> GetHotelWithPicturesByIdAsync(Guid id);
    }
}