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
    public class PlaceService:IPlaceService
    {

        private readonly PlaceRepository _placeRepository;
        private readonly IService<Place> _service;
        private readonly IService<Attributes> _Attservice;
        private readonly AttributesRepository _attributesRepository;
        private readonly IService<ExtensionStrings> _extensionService;
        private readonly IService<Comments> _commentservice;
        private readonly ClaimsPrincipal? _loggedUser;
        private readonly IService<Customer> _customerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _tokenService;

        public PlaceService(IService<Comments> commentservice,IService<Attributes> attservice, IJwtTokenService tokenService, IService<Place> service,IUnitOfWork unitOfWork,IMapper mapper, IHttpContextAccessor httpContextAccessor, PlaceRepository placeRepository, AttributesRepository attributesRepository, IService<ExtensionStrings> extensionService, IService<Customer> customerService )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _placeRepository = placeRepository;
            _attributesRepository = attributesRepository;
            _extensionService = extensionService;
            _customerService = customerService;
            _service= service;
            _commentservice= commentservice;
            _Attservice = attservice;
            _tokenService = tokenService;
            _loggedUser = httpContextAccessor.HttpContext?.User;
        }

        public async Task<IResults> AddAttr(AttrDto attr)
        {
            var realAttr = _mapper.Map<Attributes>(attr);
            await _Attservice.AddAsync(realAttr);
            
            return new SuccessResult();
        }

        public async Task<IDataResults<ICollection<AttrDto>>> GetAttr(int placeId)
        {
            var query = _attributesRepository.Where(x => x.placeId == placeId);
            var data = _mapper.Map<ICollection<AttrDto>>(await query.ToListAsync());
            var totalCount = await query.CountAsync();
            return new SuccessDataResult<ICollection<AttrDto>>(data, totalCount);
        }
        public async Task<IDataResults<ICollection<CommentResDto>>> GetPlaceComments(int placeId)
        {
            var query = _commentservice.Where(x => x.placeId == placeId&& !x.IsDeleted);
            var data = _mapper.Map<ICollection<CommentResDto>>(await query.ToListAsync());
            foreach (var comment in data)
            {
                var user = await _customerService.GetByIdAsync(x => x.Id == comment.CustomerId);
                comment.CustomerName = user.Name;
            }
            var totalCount = await query.CountAsync();
            return new SuccessDataResult<ICollection<CommentResDto>>(data, totalCount);
        }
        public async Task<IDataResults<PlaceDto>> GetById(int id)
        {
            var place = await  _placeRepository.GetByIdAsync(x => x.Id == id);

           
            var data = _mapper.Map<PlaceDto>( place);
            return new SuccessDataResult<PlaceDto>(data);
        }
        public async Task<IResults> Put(UpdatePlace entiti)
        {

            var id = GetLoggedUserId();
            var place = _mapper.Map<Place>(entiti);
            place.cusutomerId = (int)id;
            await _service.UpdateAsync(place);
                

            return new SuccessResult();
        }
        public async Task<IResults> Delete(int id)
        {
            var place = await _placeRepository.GetByIdAsync(x => x.Id == id);

         

            place.IsDeleted = true;
            await _service.UpdateAsync(place);


            return new SuccessResult();
        }

        public int? GetLoggedUserId()
        {
            var userRoleString = _loggedUser.FindFirstValue("Id");
            if (int.TryParse(userRoleString, out var userId))
            {

                return userId;
            }
            return null;
        }
        public async Task<IDataResults<Place>> Register(PlaceDto registerDto)
        {


            var valResult = FluentValidationTool.ValidateModelWithKeyResult<PlaceDto>(new PlaceRegisterValidator(), registerDto);
            if (valResult.Success == false)
            {

                return new ErrorDataResults<Place>(HttpStatusCode.BadRequest, valResult.Errors);
            }

           
           
            var id=GetLoggedUserId();



            var place = new Place()
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Mail = registerDto.Mail,
                cusutomerId = (int)id,
                IsDeleted = false,
                Name = registerDto.Name,
                Address = registerDto.Address,
                Phone=registerDto.Phone


            };

                    await _service.AddAsync(place);
            await _unitOfWork.CommitAsync();

            return new SuccessDataResult<Place>(place );




        }
        public async Task<IDataResults<ICollection<ExtensionDto>>> GetPlaceExtensions(int placeId)
        {
            var query = _extensionService.Where(x => x.placeId == placeId && !x.IsDeleted);
            var data = _mapper.Map<ICollection<ExtensionDto>>(await query.ToListAsync());

            var totalCount = await query.CountAsync();
            return new SuccessDataResult<ICollection<ExtensionDto>>(data, totalCount);
        }

        public async Task<IDataResults<ICollection<PlaceDto>>> List(PlaceListParameters parameters)
        {
            var query = _placeRepository
                .Where(x => !x.IsDeleted)
                .AsNoTracking();

            switch (parameters.Order)
            {
                case ListOrderType.Ascending:
                    query = query.OrderBy(o => o.Id);
                    break;
                case ListOrderType.Descending:
                    query = query.OrderByDescending(o => o.Id);
                    break;
            }


            if (parameters.placeId.HasValue)
            {
                query = query.Where(x => x.Id == parameters.placeId.Value);
            }

         
            if (parameters.Search != null)
            {
                query = query.Where(x => x.Name.Contains(parameters.Search));
            }
            if (parameters.Skip.HasValue)
            {
                query = query.Skip(parameters.Skip.Value);
            }

            if (parameters.Take.HasValue)
            {
                query = query.Take(parameters.Take.Value);
            }



            var totalCount = await query.CountAsync();
            var data = _mapper.Map<ICollection<PlaceDto>>(await query.ToListAsync());
            return new SuccessDataResult<ICollection<PlaceDto>>(data, totalCount);
        }

    }
}
