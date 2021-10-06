using ApplicationCore.Entities;
using AutoMapper;
using PublicApi.CatalogBrandEndpoints;
using PublicApi.CatalogItemEndpoints;
using PublicApi.CatalogTypeEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CatalogItem, CatalogItemDto>();
            CreateMap<CatalogType, CatalogTypeDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
            CreateMap<CatalogBrand, CatalogBrandDto>()
                .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));
        }
    }
}
