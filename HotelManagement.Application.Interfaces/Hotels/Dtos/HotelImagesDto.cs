using HotelManagement.Domain.Models.Models.Hotels.Entities;
using System;
using System.Collections.Generic;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class HotelImagesDto
    {
        public Guid Id { get; set; }

        public List<Image> Image { get; set; }
    }
}
