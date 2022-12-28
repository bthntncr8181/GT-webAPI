using AutoMapper;
using GTBack.Core.DTO.Request;
using GTBack.Core.DTO.Response;
using GTBack.Core.Entities;
using GTBack.Core.Entities.Widgets;
using GTBack.Core.Services;
using GTBack.Repository.Models;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{

    public class PlaceController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Place> _service;
        private readonly IService<Attributes> _Attservice;
        private readonly IService<Comments> _comService;
        private readonly IService<Widget> _widget;

        private readonly CustomService _cService = new CustomService();
        private readonly IPlaceService _pService;


        public PlaceController(IService<Widget> widget, IService<Place> service,IService<Attributes> attservice, IMapper mapper, IPlaceService pService, IService<Comments> comments)
        {
            _service = service;
            _mapper = mapper;
            _pService = pService;
            _Attservice = attservice;
            _widget= widget;
            _comService = comments;
        }
 
        [HttpPost("register")]
        public async Task<IActionResult> Register( PlaceDto place)
        {
            return ApiResult(await _pService.Register(place));


        }

        

        [HttpGet("")] 
        public async Task<IActionResult> List([FromQuery] PlaceListParameters place)
        {
            return ApiResult(await _pService.List(place));


        }
   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ApiResult(await _pService.GetById(id));


        }
        [HttpGet("profilImage")]
        public async Task<IActionResult> GetProfilImage(int id)
        {
            return ApiResult(await _pService.GetProfilImage(id));


        }
        [HttpGet("coverImage")]
        public async Task<IActionResult> GetCoverImage(int id)
        {
            return ApiResult(await _pService.GetCoverImage(id));


        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(PlaceResponseDto Entiti)
        {

            return ApiResult(await _pService.Put(Entiti));

        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {

            return ApiResult(await _pService.Delete(id));


        }
        [Authorize]
        [HttpGet("Extensions")]
        public async Task<IActionResult> GetExtensions(int id)
        {

            return ApiResult(await _pService.GetPlaceExtensions(id));


        }
        [Authorize]
        [HttpGet("Attr")]
        public async Task<IActionResult> Attr([FromQuery] int placeId)
        {
            return ApiResult(await _pService.GetAttr(placeId));


        }
        [Authorize]
        [HttpPost("Attr")]
        public async Task<IActionResult> AddAttr(AttrDto attr)
        {


            return ApiResult(await _pService.AddAttr(attr));

        }

        [HttpPost("WidgetAdd")]
        public async Task<IActionResult> AddWidgetType(string type )
        {


            var widget = new Widget()
            {
               type= type,
               IsDeleted= false,
               CreatedDate= DateTime.Now,
               UpdatedDate= DateTime.Now,



            };


            await _widget.AddAsync(widget);

            return Ok();

        }


        [HttpPost("WidgetAddOnPlace")]
        public async Task<IActionResult> AddWidgetOnPlace(int id,int placeId)
        {


            return ApiResult(await _pService.AddWidgetOnPlace(id,placeId));

        }


    }
}
