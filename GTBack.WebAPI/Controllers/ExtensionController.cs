using AutoMapper;
using GTBack.Core.DTO.Request;
using GTBack.Core.Entities;
using GTBack.Core.Services;
using GTBack.Repository.Models;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{

    public class ExtensionController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Place> _service;
        private readonly IService<Attributes> _Attservice;
        private readonly IService<Comments> _comService;
        private readonly CustomService _cService = new CustomService();
        private readonly IExtensionStringService _pService;


        public ExtensionController(IService<Place> service, IService<Attributes> attservice, IMapper mapper, IExtensionStringService pService, IService<Comments> comments)
        {
            _service = service;
            _mapper = mapper;
            _pService = pService;
            _Attservice = attservice;
            _comService = comments;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Add(ExtensionDto str)
        {
            return ApiResult(await _pService.Add(str));


        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ApiResult(await _pService.GetById(id));


        }

        [HttpPut]
        public async Task<IActionResult> Put(ExtensionDto Entiti)
        {

            return ApiResult(await _pService.Put(Entiti));

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {

            return ApiResult(await _pService.Delete(id));


        }

       
        }


    }
