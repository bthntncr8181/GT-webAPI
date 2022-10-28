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

    public class CommentController : CustomBaseController
    {

        private readonly IMapper _mapper;
        
        
        private readonly IService<Comments> _comService;
        private readonly IPlaceService _pService;

        public CommentController( IMapper mapper, IService<Comments> comments,IPlaceService pService)
        {
            _mapper = mapper;
            _comService = comments;
            _pService = pService;
        }
       



       




        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _comService.GetByIdAsync(x => x.Id == id);
            var customerDto = _mapper.Map<CommentDto>(customer);

            return CreateActionResult(CustomResponseDto<CommentDto>.Success(200, customerDto));


        }


        [HttpPut]
        public async Task<IActionResult> Put(CommentDto Entiti)
        {

            var cafe = await _comService.GetByIdAsync(x => x.Id == Entiti.Id);

            var cafe2 = _mapper.Map<Comments>(Entiti);





            await _comService.UpdateAsync(cafe2);





            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));


        }



        [HttpDelete]

        public async Task<IActionResult> DeleteById(int id)
        {


            var cafe = await _comService.GetByIdAsync(x => x.Id == id);
            cafe.IsDeleted = true;
            await _comService.UpdateAsync(cafe);

            return CreateActionResult(CustomResponseDto<CommentDto>.Success(204));


        }

    
       

        [HttpGet("Comment")]
        public async Task<IActionResult> Comment([FromQuery] int placeId)
        {



            return ApiResult(await _pService.GetPlaceComments(placeId));

        }


        [HttpPost("Comment")]

        public async Task<IActionResult> Comment(CommentDto com)
        {


            var user = await _comService.AddAsync(_mapper.Map<Comments>(com));


            var userDto = _mapper.Map<CommentDto>(user);



            return CreateActionResult(CustomResponseDto<CommentDto>.Success(201, userDto));

        }

    }
}
