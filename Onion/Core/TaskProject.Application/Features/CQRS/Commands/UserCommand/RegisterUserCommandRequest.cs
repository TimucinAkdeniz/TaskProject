using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.User;

namespace TaskProject.Application.Features.CQRS.Commands.UserCommand
{
    public class RegisterUserCommandRequest : IRequest<UserCreatedDto>
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
