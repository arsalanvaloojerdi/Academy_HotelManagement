﻿using FluentAssertions;
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
        public void should_be_add_facility_for_a_hotel()
        {
            var hotel = CreateSomeHotel();
            var facility = new HotelFacility(Facilities.SwimmingFacility, Facilities.SwimmingFacilityDescription);

            hotel.AddFacility(facility);

            hotel.Facilities.Should().HaveCount(1).And.Contain(facility);
        }

        [Fact]
        public void should_be_add_picture_for_a_hotel()
        {
            var hotel = CreateSomeHotel();
            var picture = new HotelPicture(Pictures.LobbyPictureName, Pictures.LobbyPictureFileUrl);

            hotel.AddPictures(picture);

            hotel.Pictures.Should().HaveCount(1).And.Contain(picture);
        }

        [Fact]
        public void Picture_Count_must_be_less_than_5()
        {
            var hotel= CreateSomeHotel();

            for (int i = 0; i < 5; i++)
                hotel.AddPictures(CreateSomePicture());

            Action hotelPicture = () => hotel.AddPictures(CreateSomePicture());

            hotelPicture.Should().Throw<InvalidCountPicturesException>();
        }

        #region PrivateMethods

        private static Hotel CreateHotelWithStars(int stars)
        {
            return new Hotel(DariushHotel.Name, stars, DariushHotel.Address);
        }

        private static Hotel CreateSomeHotel()
        {
            return new Hotel(DariushHotel.Name, DariushHotel.Stars, DariushHotel.Address);
        }
        private static HotelPicture CreateSomePicture()
        {
            return new HotelPicture(Pictures.LobbyPictureName, Pictures.LobbyPictureFileUrl);
        }
         
        #endregion
    }
}
