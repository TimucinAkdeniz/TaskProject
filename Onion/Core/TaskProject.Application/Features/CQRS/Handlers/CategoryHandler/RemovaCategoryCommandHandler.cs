using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.Features.CQRS.Commands.CategoryCommand;
using TaskProject.Application.Interfaces;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Features.CQRS.Handlers.CategoryHandler
{
    public class RemovaCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public RemovaCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity != null)
            {
                await _repository.Remove(entity);
            }

            return Unit.Value;
        }
    }
}
