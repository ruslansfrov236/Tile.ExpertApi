using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Dto.History;

namespace test.business.Validator.History
{
    public class CreateHistoryValidator:AbstractValidator<CreateHistoryDto>   
    {
        public CreateHistoryValidator()
        {
            RuleFor(c => c.Title)
                            .NotEmpty()
                            .NotNull()
                            .WithMessage("Please do not enter blank information.");
        }
    }
}
