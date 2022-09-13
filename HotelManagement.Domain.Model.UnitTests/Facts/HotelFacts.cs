using FluentAssertions;
using HotelManagement.Domain.Models.Models.Hotels;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using HotelManagement.Domain.Models.UnitTests.Constants;
using System;
using System.Net.Mime;
using Xunit;

namespace HotelManagement.Domain.Models.UnitTests.Facts
{
    public class HotelFacts
    {
        [Fact]
        public void Should_be_register_a_hotel_successfully()
        {
            // Red
            // Green
            // Refactor

            var hotel = new Hotel(DariushHotel.Name, DariushHotel.Stars, DariushHotel.Address , new Image("Dariush.jpg",@"D:\Pictures"));

            hotel.Name.Should().Be(DariushHotel.Name);
            hotel.Stars.Should().Be(DariushHotel.Stars);
            hotel.Address.Should().Be(DariushHotel.Address);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Stars_must_be_greater_than_2(int stars)
        {
            // Obscure Tests = Irrelevant information

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
        
        private static Image CreateSomeImage()
        {
            return new Image("9.jpg", @"D:\Source");
        }

        #region PrivateMethods

        private static Hotel CreateHotelWithStars(int stars)
        {
            return new Hotel(DariushHotel.Name, stars, DariushHotel.Address , new Image("Dariush.jpg",@"D:\Pictures"));
        }
        private static Hotel CreateHotelWithImage(Image image)
        {
            return new Hotel(DariushHotel.Name, DariushHotel.Stars, DariushHotel.Address, image);
        }
        private static Hotel CreateSomeHotel()
        {
            return new Hotel(DariushHotel.Name, DariushHotel.Stars, DariushHotel.Address , new Image("Dariush.jpg",@"D:\Pictures"));
        }

        #endregion
    }
}
