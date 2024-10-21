using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Dto.Request;

namespace test.business.Validator.Request
{
    public class CreateRequestValidator : AbstractValidator<CreateRequestDto>
    {

        public CreateRequestValidator()
        {
            RuleFor(c => c.Name)
                             .NotEmpty()
                             .NotNull()
                             .WithMessage("Please do not enter blank information.")
                             .MaximumLength(150)
                             .MinimumLength(4)
                             .WithMessage("Please enter information between 4 and 150 characters.");

            RuleFor(c => c.Description)
                              .NotEmpty()
                             .NotNull()
                             .WithMessage("Please do not enter blank information.")
                             .MaximumLength(150)
                             .MinimumLength(4)
                             .WithMessage("Please enter information between 4 and 150 characters.");

            RuleFor(c=>c.Phone)
                             .NotEmpty()
                             .NotNull()
                             .WithMessage("Please do not enter blank information.")
                             .Matches(@"^(\+?[0-9]{1,3})?[-. ]?(\(?[0-9]{1,4}?\)?[-. ]?)?[0-9]{1,4}[-. ]?[0-9]{1,4}[-. ]?[0-9]{1,9}$")
                             .WithMessage("Invalid phone number format.");

            RuleFor(c=>c.Email)
                              .NotEmpty()
                             .NotNull()
                             .WithMessage("Please do not enter blank information.")
                             .EmailAddress()
                             .WithMessage("Invalid email  format.");

        }
    }
}
