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

        public Guid Id { get;  set; }

        public string Name { get;  set; }

        public string Description { get;  set; }
    }
}