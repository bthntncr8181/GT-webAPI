using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Entities.Restourant;
using GTBack.Core.Services;
using GTBack.Core.Services.Restourant;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers.Restourant
{
    public class AuthController : CustomRestourantBaseController
    {
        
        private readonly IMapper _mapper;
        private readonly IService<Client> _service;
        private readonly IClientService _clientService;

        public AuthController(IService<Client> service, IMapper mapper,IClientService clientService)
        {
            _clientService = clientService;
            _service = service;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            
            return ApiResult(await _clientService.Me());
        }
            
            
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto log)
        {
            
            
            return ApiResult(await _clientService.Login(log));
            
            
        }
            
        [HttpPost("Register")]
        public async Task<IActionResult> Register(ClientRegisterRequestDTO request)
        {
            
            
            return ApiResult(await _clientService.Register(request));
        }

        [HttpPost("GoogleLogin")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginDTO request)
        {
            return ApiResult(await _clientService.GoogleLogin(request));
        }


            

    }
}