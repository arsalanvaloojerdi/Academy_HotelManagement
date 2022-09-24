using System;
using System.Reflection.Metadata;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class Image
    {
        public Image(string name, string url)
        {
            Name = name;
            Url = url;
        }
        public string Name { get;  private set; }
        public string Url { get; private set; }
    }
}