using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagement.Domain.Models.Models.Hotels
{
    public class Hotel
    {
        private readonly List<HotelFacility> _facilities = new List<HotelFacility>();
        private readonly List<HotelPicture> _hotelsPictures = new List<HotelPicture>();

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
        public IEnumerable<HotelPicture> Pictures => _hotelsPictures.AsReadOnly();

        public void Modify(string name, int stars)
        {
            this.Name = name;
            this.Stars = stars;
        }

        public void ModifyFacility(HotelFacility hotelFacility)
        {
            var facility = GetFacilityById(hotelFacility.Id);
            facility.Modify(hotelFacility.Name, hotelFacility.Description);
        }

        public void DeleteFacility(Guid id)
        {
            var facility = GetFacilityById(Id);
            facility.Delete();
        }

        public void AddFacility(HotelFacility facility)
        {
            // leaky abstraction
            // Some business rules
            // Example : Check uniqueness

            this._facilities.Add(facility);
        }
        public void AddPictures(HotelPicture hotelsPictures)
        {
            GuardAgainstInvalidCountPictures((sbyte)_hotelsPictures.Count);

            this._hotelsPictures.Add(hotelsPictures);
        }
        public HotelFacility GetFacilityById(Guid id)
        {
            return this.Facilities.SingleOrDefault(a => a.Id == id);
        }
        private Hotel() { }

        #region PrivateMethods

        private static void GuardAgainstInvalidHotelStar(int stars)
        {
            const int minimumValidStars = 3;

            if (stars < minimumValidStars)
                throw new InvalidHotelStarException();
        }

        private static void GuardAgainstInvalidCountPictures(sbyte count)
        {
            InvalidCountPicturesException.ThrowIfInvalidCount(count);
        }

        #endregion
    }
}