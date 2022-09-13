using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class HotelPicture
    {
        public HotelPicture(string name, string fileUrl)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.FileUrl = fileUrl;
        }
       
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public string FileUrl { get; private set; }

    }
}