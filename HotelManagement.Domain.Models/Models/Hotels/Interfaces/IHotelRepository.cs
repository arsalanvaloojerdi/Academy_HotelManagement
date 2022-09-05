using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagement.Domain.Models.Models.Hotels.Interfaces
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();

        void Add(Hotel hotel);
    }
}