﻿using GTBack.Core.DTO.Request;
using GTBack.Core.DTO.Response;
using GTBack.Core.Entities;
using GTBack.Core.Entities.Widgets;
using GTBack.Core.Results;
using GTBack.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Services
{
    public interface IPlaceService
    {

        Task<IDataResults<GalleryWidgetRequestDto>> AddGallery(GalleryWidgetRequestDto menu);
        Task<IResults> UpdateGallery(GalleryWidgetRequestDto menu);
        Task<IDataResults<ICollection<GalleryWidgetRequestDto>>> GetPlaceGallery(int placeId);
        Task<IResults> DeleteGalleryItem(int id);
        Task<IResults> UsernameCheck(string username);
        Task<IDataResults<string>> AddWidgetOnPlace(int id, int placeId);
        Task<IDataResults<ICollection<ExtensionDto>>> GetPlaceExtensions(int placeId);
        Task<IDataResults<ICollection<PlaceResponseDto>>> List(PlaceListParameters parameters);
        Task<IResults> DeleteMenuItem(int id);
        Task<IDataResults<ICollection<MenuWidgetUpdateDto>>> GetPlaceMenu(int placeId);
        Task<IResults> UpdateMenu(MenuWidgetUpdateDto menu);
        Task<IDataResults<MenuWidgetUpdateDto>> AddMenu(MenuWidgetRequestDto menu);
        Task<IDataResults<string>> GetProfilImage(int id);
        Task<IDataResults<string>> GetCoverImage(int id);
        Task<IDataResults<ICollection<AttrDto>>> GetAttr(int placeId);
        Task<IResults> AddAttr(AttrDto attr);
        Task<IDataResults<ICollection<CommentResDto>>> GetPlaceComments(int placeId);
        Task<IDataResults<PlaceResponseDto>> GetById (int id); 
        Task<IResults> Put(PlaceDto place);
        Task<IResults> Delete(int id);
        Task<IDataResults<PlaceResponseDto>> Register(PlaceDto registerDto);
    }
}
