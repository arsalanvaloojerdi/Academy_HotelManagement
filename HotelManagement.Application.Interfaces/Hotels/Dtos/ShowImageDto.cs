using System;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class ShowImageDto
    {
        public Guid HotelId { get; set; }
        public Guid Id { get; set; }
        
        public Image Image  { get; set; }

    }
}