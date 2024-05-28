using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.Features.CQRS.Commands.ProductCommand;
using TaskProject.Application.Interfaces;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Features.CQRS.Handlers.ProductHandler
{
    public class UpdateProductComamndHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public UpdateProductComamndHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updateEntity = await _repository.GetByIdAsync(request.Id);
            if (updateEntity != null)
            {
                updateEntity.Name = request.Name;
                updateEntity.Price = request.Price;
                updateEntity.Stock = request.Stock;
                updateEntity.CategoryId = request.CategoryId;
                await _repository.UpdateAsync(updateEntity);
            }
            
            return Unit.Value;
        }
    }
}
