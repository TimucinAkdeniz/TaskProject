using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.User;
using TaskProject.Application.Enum;
using TaskProject.Application.Features.CQRS.Commands.UserCommand;
using TaskProject.Application.Interfaces;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Features.CQRS.Handlers.UserHandler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, UserCreatedDto>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserCreatedDto> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x=>x.UserName==request.UserName);
            if (data ==null)
            {
                var user = new AppUser
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    AppRoleId = (int)RoleType.Member
                };
                var result = await _repository.CreateAsync(user);
                return _mapper.Map<UserCreatedDto>(user);
            }
            else
            {
                return new UserCreatedDto();
            }
        }
    }
}
