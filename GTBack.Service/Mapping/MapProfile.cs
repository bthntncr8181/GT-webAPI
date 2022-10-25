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
            
            CreateMap<Customer, UpdateCustomer>().ReverseMap();
            CreateMap<Customer,CustomerDto>().ReverseMap();
            CreateMap<Customer, LoginDto>().ReverseMap();
            CreateMap<Place, PlaceDto>().ReverseMap();





        }
    }
}
