using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Exceptions
{
    public class InvlidInsertCountImageException : Exception
    {
        public override string Message { get; } = "Invalid Count For Insert image";
    }
}