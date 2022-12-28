using AutoMapper;
using GTBack.Core.DTO.Request;
using GTBack.Core.DTO.Response;
using GTBack.Core.Entities;
using GTBack.Core.Entities.Widgets;
using GTBack.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{
    public class MenuWidgetController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<MenuWidget> _comService;
        private readonly IPlaceService _pService;

        public MenuWidgetController(IMapper mapper, IService<MenuWidget> comments, IPlaceService pService)
        {
            _mapper = mapper;
            _comService = comments;
            _pService = pService;
        }







        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _comService.GetByIdAsync(x => x.Id == id);
            var customerDto = _mapper.Map<MenuWidgetRequestDto>(customer);

            return CreateActionResult(CustomResponseDto<MenuWidgetRequestDto>.Success(200, customerDto));


        }


        [HttpPut]
        public async Task<IActionResult> Put(MenuWidgetUpdateDto Entiti)
        {


            return ApiResult(await _pService.UpdateMenu(Entiti));


        }



        [HttpDelete]

        public async Task<IActionResult> DeleteById(int id)
        {

            return ApiResult(await _pService.DeleteMenuItem(id));

        }




        [HttpGet("List")]
        public async Task<IActionResult> GetMenuList([FromQuery] int placeId)
        {



            return ApiResult(await _pService.GetPlaceMenu(placeId));

        }


        [HttpPost]

        public async Task<IActionResult> AddMenuItem(MenuWidgetRequestDto menu)
        {

            return ApiResult(await _pService.AddMenu(menu));


        }

    }
}
