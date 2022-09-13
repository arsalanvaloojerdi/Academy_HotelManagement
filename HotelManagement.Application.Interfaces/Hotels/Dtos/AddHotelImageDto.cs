using System;
using System.Drawing;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class AddHotelImageDto
    {
        public Guid HotelId { get; set; }

        public Image Image { get; set; }
    }
}
