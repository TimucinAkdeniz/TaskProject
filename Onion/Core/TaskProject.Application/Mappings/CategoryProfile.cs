﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.Category;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
            this.CreateMap<Category, CreatedCategoryDto>().ReverseMap();
            this.CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
