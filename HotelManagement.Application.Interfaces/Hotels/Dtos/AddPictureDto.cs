using FluentValidation;
using HotelManagement.Application.Interfaces.Extensions;
using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class AddPictureDto : IDto
    {
        public Guid HotelId { get; set; }

        public string Name { get; set; }

        public string FileUrl { get; set; }

        public void Validate()
        {
            new AddPictureDtoValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }

    public class AddPictureDtoValidator : AbstractValidator<AddPictureDto>
    {
        public AddPictureDtoValidator()
        {
            RuleFor(p => p.HotelId).NotEmpty().NotEqual(Guid.Empty);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.FileUrl).NotEmpty();
        }
    }
}