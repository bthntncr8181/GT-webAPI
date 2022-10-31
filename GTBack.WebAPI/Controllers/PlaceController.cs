using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Services;
using GTBack.Repository.Models;
using GTBack.Service.Services;
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
        private readonly CustomService _cService = new CustomService();
        private readonly IPlaceService _pService;


        public PlaceController(IService<Place> service,IService<Attributes> attservice, IMapper mapper, IPlaceService pService, IService<Comments> comments)
        {
            _service = service;
            _mapper = mapper;
            _pService = pService;
            _Attservice = attservice;
            _comService = comments;
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

        [HttpPut]
        public async Task<IActionResult> Put(UpdatePlace Entiti)
        {

            return ApiResult(await _pService.Put(Entiti));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {

            return ApiResult(await _pService.Delete(id));


        }

        [HttpGet("Attr")]
        public async Task<IActionResult> Attr([FromQuery] int placeId)
        {
            return ApiResult(await _pService.GetAttr(placeId));


        }

        [HttpPost("Attr")]
        public async Task<IActionResult> AddAttr(AttrDto attr)
        {


            return ApiResult(await _pService.AddAttr(attr));

        }


    }
}
