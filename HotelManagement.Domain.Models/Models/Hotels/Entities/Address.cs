using HotelManagement.Domain.Models.Models.Hotels.Exceptions;
using System.Collections.Generic;

namespace HotelManagement.Domain.Models.Models.Hotels.Entities
{
	public class Address
	{
		public Address(string city, string details)
		{
			GuardAgainstInvalidCity(city);

			this.City = city;
			this.Details = details;
		}


		public string City { get; private set; }

		public string Details { get; private set; }

		#region PrivateMethods

		private static void GuardAgainstInvalidCity(string city)
		{
			List<string> invalidCities = new() { "Tehran" };

			if (invalidCities.Contains(city))
				throw new InvalidHotelAddressException();
		}

		#endregion
	}
}