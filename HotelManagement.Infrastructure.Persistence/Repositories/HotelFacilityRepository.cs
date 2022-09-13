using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Infrastructure.Persistence.Repositories
{
    public class HotelFacilityRepository : IHotelFacilityRepository
    {
        private readonly DatabaseContext _context;
        private readonly IHotelRepository _hotelRepository;

        public HotelFacilityRepository(DatabaseContext context, IHotelRepository hotelRepository)
        {
            _context = context;
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<HotelFacility>> GetAllHotelFacilitiesAsync(Guid hotelId)
        {
            // How make it actually async?

            var hotel = _hotelRepository.GetByIdAsync(hotelId).Result;

            return hotel.Facilities;
        }

        public async Task<HotelFacility> GetByIdAsync(Guid hotelId, Guid id)
        {
            // can we find facility just by its id alone? (FindAsync(id))

            return await _context.HotelsFacility.Where(f => f.HotelId == hotelId && f.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
