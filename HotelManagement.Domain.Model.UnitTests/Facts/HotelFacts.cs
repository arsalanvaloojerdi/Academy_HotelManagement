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
        public void Manager_can_register_a_hotel_successfully()
        {
            // Red
            // Green
            // Refactor

            var hotel = new Hotel(DariushHotel.Name, DariushHotel.Stars, DariushHotel.Address);

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
        public void Hotel_City_Must_Not_Be_Tehran()
        {
            Func<Hotel> hotel = () => CreateHotel();

            hotel.Should().Throw<TheInvalidHotelCityException>();

        }
        private static Hotel CreateHotel()
        {
            var address = new Address("Tehran", "Fereshte");
            var hotel = new Hotel("Negar", 5, address);
            return hotel;
        }

        #region PrivateMethods

        private static Hotel CreateHotelWithStars(int stars)
        {
            return new Hotel(DariushHotel.Name, stars, DariushHotel.Address);
        }

        #endregion
    }
}
