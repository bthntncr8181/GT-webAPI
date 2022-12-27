using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Models;
using GTBack.Core.Services;
using GTBack.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GTBack.WebAPI.Controllers
{
    
    public class CustomerController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Customer> _service;
        private readonly ICustomerService _CustomerService;
        private readonly CustomService _cService = new CustomService();

        public CustomerController(IService<Customer> service, IMapper mapper, ICustomerService customerservice)
        {
            _CustomerService = customerservice;
            _service = service;
            _mapper = mapper;
        }
  




        [HttpGet]
        public async Task<IActionResult> All([FromQuery] CustomerListParameters param)
        {
            return ApiResult(await _CustomerService.List(param));


        }
        [Authorize]
        [HttpGet("Place")]
        public async Task<IActionResult> GetPlace()
        {
            return ApiResult(await _CustomerService.CustomerHasPlace());


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ApiResult(await _CustomerService.GetById(id));


        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomer Entiti)
        {

            return ApiResult(await _CustomerService.Put(Entiti));



        }
        [HttpPost("Interaction")]
        public async Task<IActionResult> Interaction(InteractionDto inter)
        {

            return ApiResult(await _CustomerService.Interaction(inter));



        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {

            return ApiResult(await _CustomerService.Delete(id));




        }


    }
}
