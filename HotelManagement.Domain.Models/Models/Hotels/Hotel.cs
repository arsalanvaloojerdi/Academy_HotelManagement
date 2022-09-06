using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using System;

namespace HotelManagement.Domain.Models.Models.Hotels
{
    public class Hotel
    {
        public Hotel(string name, int stars, Address address)
        {
            GuardAgainstInvalidHotelStar(stars);

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Stars = stars;
            this.Address = address;
        }
        
        public Hotel(Guid id,string name, int stars, Address address)
        {
            GuardAgainstInvalidHotelStar(stars);

            this.Id = id;
            this.Name = name;
            this.Stars = stars;
            this.Address = address;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Stars { get; private set; }

        public Address Address { get; private set; }

        private Hotel() { }

        #region PrivateMethods

        private static void GuardAgainstInvalidHotelStar(int stars)
        {
            const int minimumValidStars = 3;

            if (stars < minimumValidStars)
                throw new InvalidHotelStarException();
        }

        #endregion
    }
}