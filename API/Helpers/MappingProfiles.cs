using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using API.Dtos;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(p => p.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(p => p.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }


    }
}