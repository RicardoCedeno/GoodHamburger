using AutoMapper;
using GoodHamburger.Models.Dtos;
using GoodHamburger.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHamburger.Business.Mappers
{
    public class SandwichMapper: Profile
    {
        public SandwichMapper()
        {
            CreateMap<Sandwich, SandwichDto>().ReverseMap();
        }
    }
}
