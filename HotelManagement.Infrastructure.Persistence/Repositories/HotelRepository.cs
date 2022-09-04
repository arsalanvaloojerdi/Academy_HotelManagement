using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;

namespace HotelManagement.Infrastructure.Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DatabaseContext _context;

        public HotelRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }
    }
}