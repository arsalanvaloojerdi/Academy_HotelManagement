using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;

namespace HotelManagement.Domain.Models.Models.Hotels
{
    public class Hotel
    {
        private readonly List<HotelFacility> _facilities = new List<HotelFacility>();

        public Hotel(string name, int stars, Address address, Image image)
        {
            GuardAgainstInvalidHotelStar(stars);
            GuardIfInvalidHotelCity(address);

            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Stars = stars;
            this.Address = address;
            Images.Add(image);
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public int Stars { get; private set; }

        public Address Address { get; private set; }
        
        public static List<Image>  Images { get;  set; }
        
        public HotelFacility HotelFacility { get; set; }

        public IEnumerable<HotelFacility> Facilities => _facilities.AsReadOnly();
        

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
        
        public void DeleteFacility(HotelFacility hotelFacility)
        {
            this._facilities.Remove(hotelFacility);
            IsDeleted = true;
        }
        
        public void ModifyFacility(string name , string description)
        {
            HotelFacility.Name = name;
            HotelFacility.Description = description;
        }

        public static void AddImage(Image image)
        {
            IsAbleToAddImage();
            Images.Add(image);
        }

        public List<Image> ShowHotelImage()
        {
            return Images;
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

        private static bool IsAbleToAddImage()
        {
            var InvalidCountInsertImage = (Images.Count < 5);

            if (InvalidCountInsertImage)
            {
                throw new InvlidInsertCountImageException();
            }
            
            return false;
        }

        #endregion
    }
}