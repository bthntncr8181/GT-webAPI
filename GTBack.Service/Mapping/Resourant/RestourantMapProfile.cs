using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Entities.Restourant;

namespace GTBack.Service.Mapping.Resourant;

public class RestourantMapProfile
{
    public class MapProfile:Profile
    {

        public MapProfile()
        {
            CreateMap<Client, ClientRegisterRequestDTO>().ReverseMap();
            CreateMap<Client, UserDTO>().ReverseMap();
            CreateMap<Employee, EmployeeRegisterDTO>().ReverseMap();
        }
    }
}