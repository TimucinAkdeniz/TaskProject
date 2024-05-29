using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.Category;
using TaskProject.Application.Features.CQRS.Commands.CategoryCommand;

namespace TaskProject.Application.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Definition)
                .NotNull()
                .WithMessage("Definition alanı bol bırakılamaz")
                .MaximumLength(25)
                .MinimumLength(3)
                .WithMessage("Definition alanı 3-25 karakter arasında olmalıdır.");
        }
    }
}
