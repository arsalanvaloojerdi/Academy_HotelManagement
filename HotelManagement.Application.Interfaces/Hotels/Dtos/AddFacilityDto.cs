using FluentValidation;
using HotelManagement.Application.Interfaces.Extensions;
using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class AddFacilityDto : IDto
    {
        public Guid HotelId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Validate()
        {
            new AddFacilityDtoValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }

    public class AddFacilityDtoValidator : AbstractValidator<AddFacilityDto>
    {
        public AddFacilityDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("نام نمیتواند خالی باشد");
            RuleFor(p => p.Description).NotEmpty();
        }
    }
}