using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserInfo.Application.CommandsMediatR
{
    public class AddNewAddressCommandValidator : AbstractValidator<AddNewAddressCommand>
    {
        public AddNewAddressCommandValidator()
        {
            RuleFor(Address => Address.GovernateId).NotNull();
            RuleFor(Address => Address.CityId).NotNull();
            RuleFor(Address => Address.Street).NotEmpty().NotNull();
            RuleFor(Address => Address.BuildingNumber).NotNull();
            RuleFor(Address => Address.FlatNumber).NotNull();
        }
    }
}
