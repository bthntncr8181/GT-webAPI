using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Service.Mapping
{
    public class MapProfile:Profile
    {

        public MapProfile()
        {
            CreateMap<Cafe, CafeDto>().ReverseMap();
            CreateMap<Cafe, UpdateCafe>().ReverseMap();
            CreateMap<Cafe, CafeRegisterResponseDto>().ReverseMap();
            CreateMap<Category, CategoryDto >().ReverseMap();
            CreateMap<Restourant, RestourantDto>().ReverseMap();
            CreateMap<Restourant, UpdateRestourant>().ReverseMap();
            CreateMap<Customer, CustomerRegisterResponseDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomer>().ReverseMap();
            CreateMap<Customer,CustomerDto>().ReverseMap();



        }
    }
}
