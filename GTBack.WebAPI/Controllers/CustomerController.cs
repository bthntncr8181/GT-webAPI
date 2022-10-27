﻿using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Services;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{
    
    public class CustomerController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Customer> _service;
        private readonly IService<Comments> _comService;
        private readonly CustomService _cService = new CustomService();

        public CustomerController(IService<Customer> service, IMapper mapper,IService<Comments> comments)
        {
            _service = service;
            _mapper = mapper;
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


            var customerDto = _mapper.Map<CustomerDto>(result);



            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDto));

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(CustomerDto request)
        {


            _cService.CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var realuser = _mapper.Map<Customer>(request);
            realuser.Name = request.Name;
            realuser.PasswordHash = passwordHash;
            realuser.PasswordSalt = passwordSalt;


            var user = await _service.AddAsync(_mapper.Map<Customer>(realuser));


            var userDto = _mapper.Map<CustomerDto>(user);



            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, userDto));
        }


        [HttpGet]
        public async Task<IActionResult> All(int take)
        {
            var customer = await _service.GetAllAsync();
            var customerDto = _mapper.Map<List<CustomerDto>>(customer.ToList());

            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDto));


        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(x => x.Id == id);
            var customerDto = _mapper.Map<CustomerDto>(customer);

            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDto));


        }


        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomer Entiti)
        {

            var cafe = await _service.GetByIdAsync(x => x.Id == Entiti.Id);

            var cafe2 = _mapper.Map<Customer>(Entiti);

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

            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(204));


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
