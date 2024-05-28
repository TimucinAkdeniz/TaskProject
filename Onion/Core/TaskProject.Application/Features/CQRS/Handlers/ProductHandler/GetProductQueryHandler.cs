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
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {

        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByFilterAsync(x=>x.Id==request.Id);
            return _mapper.Map<ProductListDto>(product);
        }
    }
}
