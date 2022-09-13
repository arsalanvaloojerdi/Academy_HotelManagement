using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace HotelManagement.Domain.Models.Models.Hotels
{
    public class Hotel
    {
        private readonly List<HotelFacility> _facilities = new List<HotelFacility>();

        public Hotel(string name, int stars, Address address)
        {
            GuardAgainstInvalidHotelStar(stars);

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Stars = stars;
            this.Address = address;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Stars { get; private set; }

        public Address Address { get; private set; }

        public IEnumerable<HotelFacility> Facilities => _facilities.AsReadOnly();

        public List<Image> Images { get; private set; }

        public void Modify(string name, int stars)
        {
            this.Name = name;
            this.Stars = stars;
        }

        public void AddFacility(HotelFacility facility)
        {
            // leaky abstraction
            // Some business rules
            // Example : Check uniqueness

            this._facilities.Add(facility);
        }

        public void AddImage(Image image)
        {
            if (!IsValidToAddImage())
                throw new MaximumImagesCountException();

            Images.Add(image);
        }

        private Hotel() { }

        #region PrivateMethods

        private static void GuardAgainstInvalidHotelStar(int stars)
        {
            const int minimumValidStars = 3;

            if (stars < minimumValidStars)
                throw new InvalidHotelStarException();
        }

        private bool IsValidToAddImage()
        {
            const int maxCountOfImages = 5;

            return Images.Count <= maxCountOfImages;
        }

        #endregion
    }
}