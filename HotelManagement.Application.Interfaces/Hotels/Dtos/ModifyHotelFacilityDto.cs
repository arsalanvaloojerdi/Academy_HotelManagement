using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class ModifyHotelFacilityDto 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string description { get; set; }
    }
}