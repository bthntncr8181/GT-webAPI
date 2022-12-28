using AutoMapper;
using GTBack.Core.DTO.Request;
using GTBack.Core.DTO.Response;
using GTBack.Core.Entities.Widgets;
using GTBack.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{
    public class GalleryWidgetController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<GalleryWidget> _comService;
        private readonly IPlaceService _pService;

        public GalleryWidgetController(IMapper mapper, IService<GalleryWidget> comments, IPlaceService pService)
        {
            _mapper = mapper;
            _comService = comments;
            _pService = pService;
        }







        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _comService.GetByIdAsync(x => x.Id == id);

            var customerDto = _mapper.Map<GalleryWidgetRequestDto>(customer);

            return CreateActionResult(CustomResponseDto<GalleryWidgetRequestDto>.Success(200, customerDto));


        }


        [HttpPut]
        public async Task<IActionResult> Put(GalleryWidgetRequestDto Entiti)
        {


            return ApiResult(await _pService.UpdateGallery(Entiti));


        }



        [HttpDelete]

        public async Task<IActionResult> DeleteById(int id)
        {

            return ApiResult(await _pService.DeleteGalleryItem(id));

        }




        [HttpGet("List")]
        public async Task<IActionResult> GetGalleryList([FromQuery] int placeId)
        {



            return ApiResult(await _pService.GetPlaceGallery(placeId));

        }


        [HttpPost]

        public async Task<IActionResult> AddMenuItem(GalleryWidgetRequestDto menu)
        {

            return ApiResult(await _pService.AddGallery(menu));


        }

    }
}
