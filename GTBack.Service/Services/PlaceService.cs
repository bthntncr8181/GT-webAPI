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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IService<Comments> _commmentsService;
        private readonly IService<Customer> _customerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaceService(IService<Attributes> attservice, IService<Place> service,IUnitOfWork unitOfWork,IMapper mapper, PlaceRepository placeRepository, AttributesRepository attributesRepository, IService<Comments> commmentsService, IService<Customer> customerService )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _placeRepository = placeRepository;
            _attributesRepository = attributesRepository;
            _commmentsService = commmentsService;
            _customerService = customerService;
            _service= service;
            _Attservice = attservice;
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
            var query = _commmentsService.Where(x => x.placeId == placeId&& !x.IsDeleted);
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
            

            var place = _mapper.Map<Place>(entiti);

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
        public async Task<IDataResults<PlaceDto>> Register(PlaceDto place)
        {

       




            var user = await _service.AddAsync(_mapper.Map<Place>(place));


            var userDto = _mapper.Map<PlaceDto>(user);



         
            return new SuccessDataResult<PlaceDto>(userDto);
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

            var totalCount = await query.CountAsync();

            if (parameters.Skip.HasValue)
            {
                query = query.Skip(parameters.Skip.Value);
            }

            if (parameters.Take.HasValue)
            {
                query = query.Take(parameters.Take.Value);
            }

            query = query.Where(x => x.Name == parameters.Search);


            var data = _mapper.Map<ICollection<PlaceDto>>(await query.ToListAsync());
            return new SuccessDataResult<ICollection<PlaceDto>>(data, totalCount);
        }

    }
}
