using FluentValidation.Results;
using System;
using System.Linq;

namespace HotelManagement.Application.Interfaces.Extensions
{
    public static class ValidationResultExtensions
    {
        public static void RaiseExceptionIfRequired(this ValidationResult validationResult)
        {
            if (validationResult.Errors.Any())
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);
        }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string? message) : base(message)
        {
        }
    }
}