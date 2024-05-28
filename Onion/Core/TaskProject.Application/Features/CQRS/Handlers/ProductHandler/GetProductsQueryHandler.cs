using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.Product;
using TaskProject.Application.Features.CQRS.Queries.ProductQueries;
using TaskProject.Application.Interfaces;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Features.CQRS.Handlers.ProductHandler
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var productList = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(productList);

        }
    }
}
