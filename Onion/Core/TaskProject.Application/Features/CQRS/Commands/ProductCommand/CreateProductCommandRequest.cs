using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.Product;

namespace TaskProject.Application.Features.CQRS.Commands.ProductCommand
{
    public class CreateProductCommandRequest : IRequest<CreateProductDto>
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
