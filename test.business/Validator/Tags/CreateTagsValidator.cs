using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Dto.Tags;

namespace test.business.Validator.Tags
{
    public class CreateTagsValidator : AbstractValidator<CreateTagsDto>
    {

        public CreateTagsValidator()
        {
            RuleFor(c => c.Title)
                             .NotEmpty()
                             .NotNull()
                             .WithMessage("Please do not enter blank information.")
                             .MaximumLength(150)
                             .MinimumLength(4)
                             .WithMessage("Please enter information between 4 and 150 characters.");
        }
    }
}
