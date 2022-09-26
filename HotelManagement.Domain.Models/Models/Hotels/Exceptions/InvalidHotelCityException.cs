using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Exceptions
{
    public class InvalidHotelCityException : Exception
    {
        public override string Message { get; } = "The City is Invalid ";
    }
}