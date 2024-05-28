using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Application.DTo.Product;
using TaskProject.Domain.Entities;

namespace TaskProject.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
            this.CreateMap<Product, CreateProductDto>().ReverseMap();
            this.CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
