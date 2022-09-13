using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class ModifyHotelFacilityDto
    {
        public Guid Id { get; set; }

        public Guid HotelId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
