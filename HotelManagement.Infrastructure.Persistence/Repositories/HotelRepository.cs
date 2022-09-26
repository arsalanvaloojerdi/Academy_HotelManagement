using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Persistence.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DatabaseContext _context;

        public HotelRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _context.Hotels
                .ToListAsync();
        }
        
        public async Task<Hotel> GetByIdAsync(Guid id)
        {
            return await _context.Hotels
                .FindAsync(id);
        }

        public void Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
        }

        public void AddImage(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
        }

        public void Delete(Hotel hotel)
        {
         _context.Remove(hotel);
        }
    }
}