using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.Category;

namespace TaskProject.Application.Features.CQRS.Commands.CategoryCommand
{
    public class CreateCategoryCommandRequest : IRequest<CreatedCategoryDto>
    {
        public string? Definition { get; set; }

    }
}
