using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class HotelFacility
    {
        public HotelFacility(string name, string description, Guid hotelId)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
            this.HotelId = hotelId;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public bool IsRemoved { get; private set; }

        [ForeignKey(nameof(Hotel))]
        public Guid HotelId{ get; set; }
        
        public Hotel Hotel { get; set; }

        public void Modify(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Disable()
        {
            this.IsRemoved = true;
        }
    }
}