using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Services;
using GTBack.Repository;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace GTBack.WebAPI.Controllers
{

    public class CafesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Cafe> _service;
        private readonly CustomService _cService= new CustomService();

        public CafesController(IService<Cafe> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CafeDto request)
        {


            _cService.CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var realuser = _mapper.Map<Cafe>(request);
            realuser.Name = request.Name;
            realuser.PasswordHash = passwordHash;
            realuser.PasswordSalt = passwordSalt;
          

            var user = await _service.AddAsync(_mapper.Map<Cafe>(realuser));


            var userDto = _mapper.Map<CafeRegisterResponseDto>(user);
      


            return CreateActionResult(CustomResponseDto<CafeRegisterResponseDto>.Success(201, userDto));
        }

       
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cafes = await _service.GetAllAsync();
            var cafeDtos=_mapper.Map<List<CafeDto>>(cafes.ToList());
   
               return CreateActionResult(CustomResponseDto<List<CafeDto>>.Success(200,cafeDtos));

            
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var cafe = await _service.GetByIdAsync(x=>x.Id==id);
            var cafeDto = _mapper.Map<CafeDto>(cafe);
          
            return CreateActionResult(CustomResponseDto<CafeDto>.Success(200, cafeDto));


        }


        [HttpPut]
        public async Task<IActionResult> Put(UpdateCafe Entiti)
        {

            var cafe = await _service.GetByIdAsync(x => x.Id==Entiti.Id);
            
            var cafe2 = _mapper.Map<Cafe>(Entiti);

            cafe2.PasswordSalt = cafe.PasswordSalt;
            cafe2.PasswordHash = cafe.PasswordHash;
            cafe2.CategoryId = cafe.CategoryId;


    
            await _service.UpdateAsync(cafe2);


           


            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));


        }



        [HttpDelete]

        public async Task<IActionResult> DeleteById(int id)
        {


            var cafe = await _service.GetByIdAsync(x => x.Id == id);
             await _service.RemoveAsync(cafe);

            return CreateActionResult(CustomResponseDto<CafeDto>.Success(204));


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


            var customerDto = _mapper.Map<CafeDto>(result);



            return CreateActionResult(CustomResponseDto<CafeDto>.Success(200, customerDto));

        }

    }


  
}
