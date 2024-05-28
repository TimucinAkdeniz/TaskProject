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
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public RemoveProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                await _repository.Remove(deletedEntity);
            }
            return Unit.Value;
        }
    }
}
