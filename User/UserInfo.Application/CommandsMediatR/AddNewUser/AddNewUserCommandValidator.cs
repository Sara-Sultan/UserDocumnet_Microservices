using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UserInfo.Application.CustomValidators;

namespace UserInfo.Application.CommandsMediatR
{
    public class AddNewUserCommandValidator : AbstractValidator<AddNewUserCommand>
    {
        public AddNewUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull().Length(2, 20)
          .MatchNameArEnValidatorRule()
          .WithMessage("Please provide valid Name with English & Arabic");

            RuleFor(x => x.MiddleName).NotEmpty().NotNull().Length(2, 40)
               .MatchNameArEnValidatorRule()
               .WithMessage("Please provide valid Name with English & Arabic");

            RuleFor(x => x.LastName).NotEmpty().NotNull().Length(2, 20)
               .MatchNameArEnValidatorRule()
               .WithMessage("Please provide valid Name with English & Arabic");

            RuleFor(x => x.BirthDate)
           .Must(AgeValidate.AgeGreaterThan20)
           .WithMessage("Invalid date student age must be 20 or greater than 20");

            RuleFor(x => x.MobileNumber)
               .MatchMobileNumberRule()
               .WithMessage("Please provide valid phone number");

            RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Please provide valid email");

            RuleForEach(x => x.Addresses).SetValidator(new AddNewAddressCommandValidator());
        }
    }
}
