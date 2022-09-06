using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class HotelFacility
    {
        public HotelFacility(string name, string description)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }
    }
}