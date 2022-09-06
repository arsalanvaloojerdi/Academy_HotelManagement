using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Stars { get; set; }
    }
}