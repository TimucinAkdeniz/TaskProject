using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.User;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Mappings
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            this.CreateMap<AppUser, UserCreatedDto>().ReverseMap();
        }
    }
}
