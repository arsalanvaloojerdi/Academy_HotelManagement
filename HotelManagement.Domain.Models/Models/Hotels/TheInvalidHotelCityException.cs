using System;
using System.Runtime.Serialization;

namespace HotelManagement.Domain.Models.Models.Hotels
{
    [Serializable]
    public class TheInvalidHotelCityException : Exception
    {
        public TheInvalidHotelCityException()
        {
        }

        public TheInvalidHotelCityException(string message) : base(message)
        {
        }

        public TheInvalidHotelCityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TheInvalidHotelCityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}