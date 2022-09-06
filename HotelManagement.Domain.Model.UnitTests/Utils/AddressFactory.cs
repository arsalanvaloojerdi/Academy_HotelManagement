using HotelManagement.Domain.Models.Models.Hotels.Entities;

namespace HotelManagement.Domain.Models.UnitTests.Utils
{
	public class AddressFactory
	{
		private readonly string _details;

		public AddressFactory()
		{
			_details = "Enghelab Sqaure";
		}


		public Address GetSomeAddress(string city)
		{
			return new Address(city, _details);
		}
	}
}
