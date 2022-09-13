using FluentValidation;
using HotelManagement.Application.Interfaces.Extensions;
using System;

namespace HotelManagement.Application.Interfaces.Hotels.Dtos
{
    public class ModifyFacilityDto : IDto
    {
        public Guid Id { get; set; }
        public Guid HotelId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public void Validate()
        {
            new ModifyFacilityDtoValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }

    public class ModifyFacilityDtoValidator : AbstractValidator<ModifyFacilityDto>
    {
        public ModifyFacilityDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("نام نمیتواند خالی باشد");
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Id).NotEmpty().NotEqual(Guid.Empty);
        }
    }
}