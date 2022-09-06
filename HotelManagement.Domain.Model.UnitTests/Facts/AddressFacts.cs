using FluentAssertions;
using HotelManagement.Domain.Models.Models.Hotels.Entities;
using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using HotelManagement.Domain.Models.UnitTests.Utils;
using System;
using Xunit;

namespace HotelManagement.Domain.Models.UnitTests.Facts
{
	public class AddressFacts
	{
		private readonly AddressFactory _addressFactory;
		public AddressFacts()
		{
			_addressFactory = new AddressFactory();
		}

		[Theory]
		[InlineData("Tehran")]
		public void Address_should_throw_with_invalid_city(string city)
		{
			Func<Address> address = () => _addressFactory.GetSomeAddress(city);

			address.Should().Throw<InvalidHotelAddressException>();
		}
	}
}
