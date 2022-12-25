using GTBack.Core.DTO;
using GTBack.Core.Entities;
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
        Task<IDataResults<ICollection<ExtensionDto>>> GetPlaceExtensions(int placeId);
        Task<IDataResults<ICollection<PlaceDto>>> List(PlaceListParameters parameters);


        Task<IDataResults<string>> GetProfilImage(int id);
        Task<IDataResults<string>> GetCoverImage(int id);


        Task<IDataResults<ICollection<AttrDto>>> GetAttr(int placeId);
        Task<IResults> AddAttr(AttrDto attr);
        Task<IDataResults<ICollection<CommentResDto>>> GetPlaceComments(int placeId);

        Task<IDataResults<PlaceDto>> GetById (int id); 
        

        Task<IResults> Put(UpdatePlace place);
       

        Task<IResults> Delete(int id);

        Task<IDataResults<PlaceResponseDto>> Register(PlaceDto registerDto);
    }
}
