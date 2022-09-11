using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class ModifyHotelDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }
    }
}