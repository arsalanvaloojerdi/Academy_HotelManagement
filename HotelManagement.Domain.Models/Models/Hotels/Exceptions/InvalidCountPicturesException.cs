using System;

namespace HotelManagement.Domain.Models.Models.Hotels.Exceptions
{
    public class InvalidCountPicturesException : Exception
    {
        const sbyte maxCount = 5;

        public InvalidCountPicturesException()
        {

        }
        public InvalidCountPicturesException(string message) : base(message)
        {

        }

        public static void ThrowIfInvalidCount(sbyte listCount)
        {
            if (listCount == maxCount)
                throw new InvalidCountPicturesException();
        }

    }
}