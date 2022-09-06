using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace HotelManagement.Infrastructure.Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DatabaseContext _context;

        public HotelRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Hotel GetById(Guid id)
        => _context.Hotels.Find(id);


        public void Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }
    }
}