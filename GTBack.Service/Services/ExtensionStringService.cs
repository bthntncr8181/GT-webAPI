using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Enums;
using GTBack.Core.Repositories;
using GTBack.Core.Results;
using GTBack.Core.Services;
using GTBack.Core.UnitOfWorks;
using GTBack.Repository.Models;
using GTBack.Repository.Repositories;
using GTBack.Service.Utilities.Jwt;
using GTBack.Service.Validation;
using GTBack.Service.Validation.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Service.Services
{
    public class ExtensionStringService : IExtensionStringService
    {

        private readonly PlaceRepository _placeRepository;
        private readonly IService<ExtensionStrings> _service;
        private readonly IService<Attributes> _Attservice;
        private readonly AttributesRepository _attributesRepository;
        private readonly IService<Comments> _commmentsService;
        private readonly ClaimsPrincipal? _loggedUser;
        private readonly IService<Customer> _customerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _tokenService;

        public ExtensionStringService(IService<Attributes> attservice, IJwtTokenService tokenService, IService<ExtensionStrings> service, IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, PlaceRepository placeRepository, AttributesRepository attributesRepository, IService<Comments> commmentsService, IService<Customer> customerService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _placeRepository = placeRepository;
            _attributesRepository = attributesRepository;
            _commmentsService = commmentsService;
            _customerService = customerService;
            _service = service;
            _Attservice = attservice;
            _tokenService = tokenService;
            _loggedUser = httpContextAccessor.HttpContext?.User;
        }

  

    
        public async Task<IDataResults<ExtensionDto>> GetById(int id)
        {
            var place = await _service.GetByIdAsync(x => x.Id == id);


            var data = _mapper.Map<ExtensionDto>(place);
            return new SuccessDataResult<ExtensionDto>(data);
        }
        public async Task<IResults> Put(ExtensionDto entiti)
        {
            var data = _mapper.Map<ExtensionStrings>(entiti);
            await _service.UpdateAsync(data);


            return new SuccessResult();
        }
        public async Task<IResults> Delete(int id)
        {
            var str = await _service.GetByIdAsync(x => x.Id == id);



            str.IsDeleted = true;
            await _service.UpdateAsync(str);


            return new SuccessResult();
        }

      
        public async Task<IDataResults<ExtensionDto>> Add(ExtensionDto registerDto)
        {



            var place = new ExtensionStrings()
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                placeId = registerDto.placeId,
                IsDeleted = false,
                Content = registerDto.Content,
                Type = registerDto.Type,
             


            };

            
            await _service.AddAsync(place);
            await _unitOfWork.CommitAsync();
            var data = _mapper.Map<ExtensionDto>(place);
            return new SuccessDataResult<ExtensionDto>(data);




        }


      


    }
}
