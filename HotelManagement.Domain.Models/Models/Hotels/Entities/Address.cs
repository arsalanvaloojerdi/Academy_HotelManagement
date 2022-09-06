using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
    public class Address
    {
        public Address(string city, string details)
        {
            GuardAgainstInvalidTehranCity(city);
            this.City = city;
            this.Details = details;
        }

        public string City { get; private set; }

        public string Details { get; private set; }
        
        private static void GuardAgainstInvalidTehranCity(string city)
        {
            InvalidTehranCityException.ThrowIfTehranCity(city);
        }
    }
}