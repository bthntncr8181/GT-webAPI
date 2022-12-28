using AutoMapper;
using GTBack.Core.DTO.Request;
using GTBack.Core.DTO.Response;
using GTBack.Core.Entities;
using GTBack.Core.Entities.Constants;
using GTBack.Core.Entities.Widgets;
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
            
            CreateMap<Customer, UpdateCustomer>().ReverseMap();
            CreateMap<Customer,CustomerDto>().ReverseMap();
            CreateMap<Customer, LoginDto>().ReverseMap();
            CreateMap<Place, PlaceDto>().ReverseMap();
            CreateMap<Attributes, AttrDto>().ReverseMap();
            CreateMap<Comments, CommentDto>().ReverseMap();
            CreateMap<CommentResDto, Comments>().ReverseMap();
            CreateMap<RefreshToken, RefreshTokenDto>().ReverseMap();
            CreateMap<ExtensionStrings, ExtensionDto>().ReverseMap();
            CreateMap<PlaceCustomerInteraction, InteractionDto>().ReverseMap();
            CreateMap<PlaceResponseDto, Place>().ReverseMap();
            CreateMap<MenuWidget, MenuWidgetRequestDto>().ReverseMap();
            CreateMap<MenuWidgetUpdateDto, MenuWidgetUpdateDto>().ReverseMap();
            CreateMap<MenuWidget, MenuWidgetUpdateDto>().ReverseMap();
            CreateMap<GalleryWidget, GalleryWidgetRequestDto>().ReverseMap();










        }
    }
}
