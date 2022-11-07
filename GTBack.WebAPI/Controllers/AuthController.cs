using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Models;
using GTBack.Core.Services;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{
    public class AuthController : CustomBaseController
    {
      
      

            private readonly IMapper _mapper;
            private readonly IService<Customer> _service;
            private readonly ICustomerService _CustomerService;

            public AuthController(IService<Customer> service, IMapper mapper, ICustomerService customerservice)
            {
                _CustomerService = customerservice;
                _service = service;
                _mapper = mapper;
            }

            [Authorize]
            [HttpGet("me")]
            public async Task<IActionResult> Me()
            {

                return ApiResult(await _CustomerService.Me());
            }
        [HttpGet("UsernameControl")]
        public async Task<IActionResult> UsernameControl()
        {

            return ApiResult(await _CustomerService.Me());
        }
        [HttpGet("EmailControl")]
        public async Task<IActionResult> EmailControl()
        {

            return ApiResult(await _CustomerService.Me());
        }


        [HttpPost("Login")]
            public async Task<IActionResult> Login(LoginDto log)
            {


                return ApiResult(await _CustomerService.Login(log));


            }

            [HttpPost("Register")]
            public async Task<IActionResult> Register(CustomerDto request)
            {


                return ApiResult(await _CustomerService.Register(request));
            }





        }
    }

