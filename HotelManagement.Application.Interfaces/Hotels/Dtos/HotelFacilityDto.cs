using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelFacilityDto 
    {
        public HotelFacilityDto(string name, string description = null)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}