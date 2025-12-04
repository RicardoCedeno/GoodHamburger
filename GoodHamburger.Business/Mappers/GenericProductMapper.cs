using AutoMapper;
using GoodHamburger.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Mappers
{
    public class GenericProductMapper : Profile
    {
        public GenericProductMapper()
        {
            CreateMap<SandwichDto, GenericProductDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SandwichName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => "Sandwich"));
            CreateMap<ExtraDto, GenericProductDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ExtraName))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => "Extra"));
        }
    }
}
