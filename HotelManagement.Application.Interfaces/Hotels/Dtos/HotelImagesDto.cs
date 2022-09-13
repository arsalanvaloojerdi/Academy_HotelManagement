using System;
using System.Collections.Generic;
using System.Drawing;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelImagesDto
    {
        public Guid Id { get; set; }

        public List<Image> Image { get; set; }
    }
}
