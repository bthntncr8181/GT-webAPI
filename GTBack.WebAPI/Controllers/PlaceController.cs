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
        [HttpPost("Login")]

        public IActionResult Login(LoginDto log)
        {



            var result = _service.Where(x => x.Username == log.UserName).FirstOrDefault();
            if (result == null)
            {
                return BadRequest("Wrong Username");
            }


            if (!_cService.VerifyPass(result.PasswordSalt, result.PasswordHash, log.password))
            {
                return BadRequest("Wrong Password");
            }


            var customerDto = _mapper.Map<PlaceDto>(result);



            return CreateActionResult(CustomResponseDto<PlaceDto>.Success(200, customerDto));

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(PlaceDto request)
        {


            _cService.CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var realuser = _mapper.Map<Place>(request);
            realuser.Name = request.Name;
            realuser.PasswordHash = passwordHash;
            realuser.PasswordSalt = passwordSalt;


            var user = await _service.AddAsync(_mapper.Map<Place>(realuser));


            var userDto = _mapper.Map<PlaceDto>(user);



            return CreateActionResult(CustomResponseDto<PlaceDto>.Success(201, userDto));
        }


        [HttpGet("")] 
        public async Task<IActionResult> List([FromQuery] PlaceListParameters place)
        {
            return ApiResult(await _pService.List(place));


        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(x => x.Id == id);
            var customerDto = _mapper.Map<PlaceDto>(customer);

            return CreateActionResult(CustomResponseDto<PlaceDto>.Success(200, customerDto));


        }


        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomer Entiti)
        {

            var cafe = await _service.GetByIdAsync(x => x.Id == Entiti.Id);

            var cafe2 = _mapper.Map<Place>(Entiti);

            cafe2.PasswordSalt = cafe.PasswordSalt;
            cafe2.PasswordHash = cafe.PasswordHash;




            await _service.UpdateAsync(cafe2);





            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));


        }



        [HttpDelete]

        public async Task<IActionResult> DeleteById(int id)
        {


            var cafe = await _service.GetByIdAsync(x => x.Id == id);
            cafe.IsDeleted = true;
            await _service.UpdateAsync(cafe);

            return CreateActionResult(CustomResponseDto<PlaceDto>.Success(204));


        }

        [HttpGet("Attr")]
        public async Task<IActionResult> Attr([FromQuery] int placeId)
        {
            return ApiResult(await _pService.GetAttr(placeId));


        }
        [HttpPost("Attr")]
        public async Task<IActionResult> AddAttr(AttrDto attr)
        {


            var user = await _Attservice.AddAsync(_mapper.Map<Attributes>(attr));


            var userDto = _mapper.Map<AttrDto>(user);



            return CreateActionResult(CustomResponseDto<AttrDto>.Success(201, userDto));

        }

        [HttpGet("Comment")]
        public async Task<IActionResult> Comment([FromQuery] int placeId)
        {



            return ApiResult(await _pService.GetPlaceComments(placeId));

        }

    }
}
