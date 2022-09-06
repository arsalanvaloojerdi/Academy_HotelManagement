using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Exceptions
{
    public class InvalidTehranCityException : ArgumentException
    {
        const string tehranCity = "tehran";

        public InvalidTehranCityException()
        {

        }
        public InvalidTehranCityException(string message):base(message)
        {

        }

        public static void ThrowIfTehranCity(string city) {
            if (city.ToLower() == tehranCity)
                throw new InvalidTehranCityException();
        }

    }
}