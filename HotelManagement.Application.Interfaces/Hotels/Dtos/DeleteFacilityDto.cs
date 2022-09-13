using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class DeleteFacilityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}