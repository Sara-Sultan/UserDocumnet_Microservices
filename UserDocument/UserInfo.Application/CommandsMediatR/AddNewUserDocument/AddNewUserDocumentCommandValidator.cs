using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Document.Application.CommandsMediatR
{
    public class AddNewUserDocumentCommandValidator : AbstractValidator<AddNewUserDocumentCommand>
    {
        public AddNewUserDocumentCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();

            RuleFor(x => x.FilePath).NotEmpty().NotNull();
            ;
        }
    }
}
