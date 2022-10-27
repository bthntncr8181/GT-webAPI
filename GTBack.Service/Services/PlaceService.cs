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
        private readonly AttributesRepository _attributesRepository;
        private readonly IService<Comments> _commmentsService;
        private readonly IService<Customer> _customerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaceService(IUnitOfWork unitOfWork,IMapper mapper, PlaceRepository placeRepository, AttributesRepository attributesRepository, IService<Comments> commmentsService, IService<Customer> customerService )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _placeRepository = placeRepository;
            _attributesRepository = attributesRepository;
            _commmentsService = commmentsService;
            _customerService = customerService;
        }

        public async Task<IResults> AddAttr(AttrDto attr)
        {
            var realAttr = _mapper.Map<Attributes>(attr);
            await _attributesRepository.AddAsync(realAttr);

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
            var query = _commmentsService.Where(x => x.placeId == placeId);
            var data = _mapper.Map<ICollection<CommentResDto>>(await query.ToListAsync());
            foreach (var comment in data)
            {
                var user = await _customerService.GetByIdAsync(x => x.Id == comment.CustomerId);
                comment.CustomerName = user.Name;
            }
            var totalCount = await query.CountAsync();
            return new SuccessDataResult<ICollection<CommentResDto>>(data, totalCount);
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
            var data = _mapper.Map<ICollection<PlaceDto>>(await query.ToListAsync());
            return new SuccessDataResult<ICollection<PlaceDto>>(data, totalCount);
        }

     
    }
}
