using FluentAssertions;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using HotelManagement.Domain.Models.UnitTests.Constants;
using System;
using Xunit;

namespace HotelManagement.Domain.Models.UnitTests.Facts
{
    public class HotelFacts
    {
        [Fact]
        public void Should_be_register_a_hotel_successfully()
        {
            var hotel = new Hotel(DariushHotel.Name, DariushHotel.Stars, DariushHotel.Address );

            hotel.Name.Should().Be(DariushHotel.Name);
            hotel.Stars.Should().Be(DariushHotel.Stars);
            hotel.Address.Should().Be(DariushHotel.Address);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Stars_must_be_greater_than_2(int stars)
        {
            Func<Hotel> hotel = () => CreateHotelWithStars(stars);

            hotel.Should().Throw<InvalidHotelStarException>();
        }

        [Fact]
        public void should_be_add_facility_for_a_hotel()
        {
            var hotel = CreateSomeHotel();
            var facility = new HotelFacility(Facilities.SwimmingFacility, Facilities.SwimmingFacilityDescription);

            hotel.AddFacility(facility);

            hotel.Facilities.Should().HaveCount(1).And.Contain(facility);
        }

        [Fact]
        public void Should_be_throw_InvalidHotelCityException_when_insert_invalidCity()
        {
            Func<Hotel> hotel = () => CreateHotelWithAdreess();

            hotel.Should().Throw<InvalidHotelCityException>();
        }
        
        [Fact]
        public void should_be_add_Image_for_a_hotel()
        {
            var hotel = CreateSomeHotel();
            
            var image = new Image("1.jpg", @"D:\Source\Academy_HotelManagement");
            hotel.AddImage(image);

            hotel.Images.Should().HaveCount(1);
        }

        [Fact]
        public void HotelFacility_Must_Be_Modified()
        {
            var hotel = CreateSomeHotel();
            var hotelFacility = CreateSomeHotelFacility();
            
            hotel.AddFacility(hotelFacility);
            hotel.ModifyFacility(hotelFacility.Id , TransportFacility.Name,TransportFacility.Description);

            hotelFacility.Name.Should().Be(TransportFacility.Name);
            hotelFacility.Description.Should().Be(TransportFacility.Description);
        }

        [Fact]
        public void HotelFacility_Must_Be_Deleted()
        {
            var hotel = CreateSomeHotel();
            var hotelFacility = CreateSomeHotelFacility();
            
            hotel.AddFacility(hotelFacility);
            hotel.DeleteFacility(hotelFacility.Id);

            hotel.Facilities.Should().HaveCount(0);
        }
        
        #region PrivateMethods

        private static Hotel CreateHotelWithStars(int stars)
        {
            return new Hotel(DariushHotel.Name, stars, DariushHotel.Address);
        }
        
        private static Hotel CreateHotelWithAdreess()
        {
            var address = new Address("Tehran", "Esteghlal Street");
            return new Hotel(DariushHotel.Name, DariushHotel.Stars, address);
        }
        private static Hotel CreateSomeHotel()
        {
            return new Hotel(DariushHotel.Name, DariushHotel.Stars, DariushHotel.Address);
        }

        private static HotelFacility CreateSomeHotelFacility()
        {
            return new  HotelFacility(Facilities.SwimmingFacility, Facilities.SwimmingFacilityDescription);
        }

        #endregion
    }
}
