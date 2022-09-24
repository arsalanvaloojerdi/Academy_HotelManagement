using System;
using System.Collections.Generic;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class ShowHotelImagesDto
    {
        public List<Image> Images  { get; set; }
    }
}