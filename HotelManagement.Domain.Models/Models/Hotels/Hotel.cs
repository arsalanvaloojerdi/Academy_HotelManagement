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
        private readonly List<Image> _images = new List<Image>() ;

        public Hotel(string name, int stars, Address address)
        {
            GuardAgainstInvalidHotelStar(stars);
            GuardIfInvalidHotelCity(address);

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
        public IEnumerable<Image> Images => _images.AsReadOnly();
        public bool IsDeleted { get; set; }

        
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
        
        public void DeleteFacility(Guid facilityId)
        {
            var facility = _facilities.FirstOrDefault(f => f.Id == facilityId);
            this._facilities.Remove(facility); 
        }
        
        public void ModifyFacility(Guid id,string name , string description)
        {
            var facility = _facilities.FirstOrDefault(f => f.Id == id);

            facility.Name = name;
            facility.Description = description;
        }

        public void AddImage(Image image)
        {
            IfIsAbleToAddImage();
            _images.Add(image);
        }

        public List<Image> GetHotelImages()
        {
            return _images;
        }


        #region PrivateMethods

        private static void GuardAgainstInvalidHotelStar(int stars)
        {
            const int minimumValidStars = 3;

            if (stars < minimumValidStars)
                throw new InvalidHotelStarException();
        }

        private static void GuardIfInvalidHotelCity(Address address)
        {
            const string invlaidCity = "Tehran";
            if (address.City == invlaidCity)
            {
                throw new InvalidHotelCityException();
            }
        }

        private bool IfIsAbleToAddImage()
        {
            const int maxImagesCount = 5;
            var invalidImagesCount = (_images.Count > maxImagesCount);

            if (invalidImagesCount)
            {
                throw new InvlidInsertCountImageException();
            }
            
            return false;
        }

        #endregion
    }
}