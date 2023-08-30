using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Results;
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
            
          
            CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
            CreateMap<UserRegisterDTO, User>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<Event, EventAddRequestDTO>().ReverseMap();
            CreateMap<ICollection<EventListClientResponseDto>, Event>().ReverseMap();
            CreateMap<EventListClientResponseDto, Event>().ReverseMap();
            CreateMap<ICollection<EventListClientResponseDto>, IQueryable<Event>>().ReverseMap();


       


        }
    }
}
