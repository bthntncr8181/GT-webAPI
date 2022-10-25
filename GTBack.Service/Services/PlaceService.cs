using AutoMapper;
using GTBack.Core.DTO;
using GTBack.Core.Enums;
using GTBack.Core.Repositories;
using GTBack.Core.Results;
using GTBack.Core.UnitOfWorks;
using GTBack.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Service.Services
{
    public class PlaceService
    {

        private readonly PlaceRepository _topicTermRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaceService(IUnitOfWork unitOfWork,
            IMapper mapper,


            PlaceRepository topicTermRepository
         
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        
            _topicTermRepository = topicTermRepository;
        
        }














        public async Task<IDataResults<ICollection<PlaceDto>>> List(PlaceListParameters parameters)
        {
            var query = _topicTermRepository
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
