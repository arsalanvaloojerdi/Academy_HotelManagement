using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelFacilityDto
    {
        public Guid HotelFacilityId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
