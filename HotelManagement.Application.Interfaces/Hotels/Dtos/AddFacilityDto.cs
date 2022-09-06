using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class AddFacilityDto
    {
        public Guid HotelId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}