using System;
using FluentAssertions;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.UnitTests.Constants;
using Xunit;

namespace HotelManagement.Domain.Models.UnitTests.Facts
{
    public class HotelFacilityFacts
    {
        [Fact]
        public void Should_be_modified_correctly()
        {
            var hotelFacility = GetSomeHotelFacility();

            hotelFacility.Modify(PartyFacility.PartyFacilityName, PartyFacility.PartyFacilityDescription);

            hotelFacility.Name.Should().Be(PartyFacility.PartyFacilityName);
            hotelFacility.Description.Should().Be(PartyFacility.PartyFacilityDescription);
        }

        [Fact]
        public void Should_be_removed_correctly()
        {
            var hotelFacility = GetSomeHotelFacility();

            hotelFacility.Disable();

            hotelFacility.IsRemoved.Should().BeTrue();
        }


        #region Private methods

        private static HotelFacility GetSomeHotelFacility()
        {
            return new HotelFacility(SwimmingFacility.SwimmingFacilityName, SwimmingFacility.SwimmingFacilityDescription, new Guid());
        }

        #endregion
    }
}
