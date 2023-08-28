using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Services;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{
    public class AuthController : CustomBaseController
    {
      
      

            private readonly IMapper _mapper;
            private readonly IService<User> _service;
            private readonly IUserService _userService;

            public AuthController(IService<User> service, IMapper mapper,IUserService userService)
            {
                _userService = userService;
                _service = service;
                _mapper = mapper;
            }

            [Authorize]
            [HttpGet("me")]
            public async Task<IActionResult> Me()
            {
            
                return ApiResult(await _userService.Me());
            }
            
            
            [HttpPost("Login")]
            public async Task<IActionResult> Login(LoginDto log)
            {
            
            
                return ApiResult(await _userService.Login(log));
            
            
            }
            
            [HttpPost("Register")]
            public async Task<IActionResult> Register(UserRegisterDTO request)
            {
            
            
                return ApiResult(await _userService.Register(request));
            }





        }
    }

