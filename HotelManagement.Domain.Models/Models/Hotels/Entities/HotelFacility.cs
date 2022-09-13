using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class HotelFacility
    {
        public HotelFacility(Guid id,string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
        public HotelFacility(string name, string description)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Description = description;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }

        public string Description { get; private set; }

        public void Modify(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}