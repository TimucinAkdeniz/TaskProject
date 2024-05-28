using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.Product;

namespace TaskProject.Application.Features.CQRS.Queries.ProductQueries
{
    public class GetProductsQueryRequest : IRequest<List<ProductListDto>>
    {
    }
}
