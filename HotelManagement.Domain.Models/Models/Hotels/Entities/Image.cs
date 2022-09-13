using System;
using System.Reflection.Metadata;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class Image
    {
        public Image(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public string Name { get;  private set; }
        public string Address { get; private set; }
    }
}