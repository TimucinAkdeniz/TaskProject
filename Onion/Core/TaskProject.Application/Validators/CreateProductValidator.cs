using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.Features.CQRS.Commands.CategoryCommand;
using TaskProject.Application.Features.CQRS.Commands.ProductCommand;

namespace TaskProject.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name alanı boş geçilemez")
                .MaximumLength(25)
                .MinimumLength(5)
                .WithMessage("Name alanı 5-25 arasında olmalıdır.");

            RuleFor(x => x.Price)
                .NotEqual(0)
                .WithMessage("Price değeri 0 olamaz")
                .GreaterThan(1500)
                .WithMessage("Price değeri 1500 den fazla olamaz");


            RuleFor(x => x.CategoryId)
                .NotNull()
                .WithMessage("CategoryId alanı boş olamaz");
        }
    }
}
