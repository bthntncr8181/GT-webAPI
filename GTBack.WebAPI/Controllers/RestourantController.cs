using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Services;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace GTBack.WebAPI.Controllers
{

    public class RestourantController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Restourant> _service;
        private readonly CustomService _cService = new CustomService();



        //Constructor
        public RestourantController(IService<Restourant> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]

        
        //GetAllRestourants
        public async Task<IActionResult> All()
        {
            var restourant = await _service.GetAllAsync();
            var restourantDtos = _mapper.Map<List<RestourantDto>>(restourant.ToList());

            return CreateActionResult(CustomResponseDto<List<RestourantDto>>.Success(200, restourantDtos));


        }

        [HttpGet("{id}")]

        //Get Restourant by ID
        public async Task<IActionResult> GetById(int id)
        {
            var restourant = await _service.GetByIdAsync(x => x.Id == id);
            var restourantDto = _mapper.Map<RestourantDto>(restourant);

            return CreateActionResult(CustomResponseDto<RestourantDto>.Success(200, restourantDto));


        }



       //Register with Restourant

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RestourantDto request)
        {


            _cService.CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var realuser = _mapper.Map<Restourant>(request);
            realuser.Name = request.Name;
            realuser.PasswordHash = passwordHash;
            realuser.PasswordSalt = passwordSalt;


            var user = await _service.AddAsync(_mapper.Map<Restourant>(realuser));


            var userDto = _mapper.Map<RestourantRegiserDtoResponse>(user);



            return CreateActionResult(CustomResponseDto<RestourantRegiserDtoResponse>.Success(201, userDto));
        }

        //Change Attributes of restourant
        [HttpPut]
        public async Task<IActionResult> Put(UpdateRestourant Entiti)
        {

            var restourant = await _service.GetByIdAsync(x => x.Id == Entiti.Id);

            var restourant2 = _mapper.Map<Restourant>(Entiti);

            restourant2.PasswordSalt = restourant.PasswordSalt;
            restourant2.PasswordHash = restourant.PasswordHash;
            restourant2.CategoryId = restourant.CategoryId;



            await _service.UpdateAsync(restourant2);





            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));


        }


        [HttpDelete]

        public async Task<IActionResult> DeleteById(int id)
        {


            var restourant = await _service.GetByIdAsync(x => x.Id == id);
            await _service.RemoveAsync(restourant);

            return CreateActionResult(CustomResponseDto<RestourantDto>.Success(204));


        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {



            var result = _service.Where(x => x.UserName == username).FirstOrDefault();
            if (result == null)
            {
                return BadRequest(" Wrong Username");
            }


            if (!_cService.VerifyPass(result.PasswordSalt, result.PasswordHash, password))
            {
                return BadRequest("Wrong Password");
            }


            var customerDto = _mapper.Map<RestourantDto>(result);



            return CreateActionResult(CustomResponseDto<RestourantDto>.Success(200, customerDto));

        }
    }
}
