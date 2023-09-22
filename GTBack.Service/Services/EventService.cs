using System.Net;
using System.Security.Claims;
using AutoMapper;
using FluentValidation;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Repositories;
using GTBack.Core.Results;
using GTBack.Core.Services;
using GTBack.Core.UnitOfWorks;
using GTBack.Service.Utilities.Jwt;
using GTBack.Service.Validation;
using GTBack.Service.Validation.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GTBack.Service.Services;

public class EventService : IEventService
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IGenericRepository<EventType> _eventTypeRepository;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IGenericRepository<EventTypeCompanyRelation> _eventTypeCompanyRelationRepository;
    private readonly IGenericRepository<Company> _companyRepository;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly ClaimsPrincipal? _loggedUser;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidatorFactory _validatorFactory;
    private readonly IJwtTokenService _tokenService;

    public EventService(IGenericRepository<Event> eventRepository,
        IGenericRepository<EventType> eventTypeRepository,
        IGenericRepository<User> userRepository,
        IGenericRepository<EventTypeCompanyRelation> eventTypeCompanyRelationRepository,
        IGenericRepository<Company> companyRepository,
        IRefreshTokenService refreshTokenService, IJwtTokenService tokenService,
        IValidatorFactory validatorFactory, IHttpContextAccessor httpContextAccessor, IService<Event> service,
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _eventRepository = eventRepository;
        _userRepository = userRepository;
        _eventTypeRepository = eventTypeRepository;
        _companyRepository = companyRepository;
        _eventTypeCompanyRelationRepository = eventTypeCompanyRelationRepository;
        _loggedUser = httpContextAccessor.HttpContext?.User;
        _validatorFactory = validatorFactory;
        _refreshTokenService = refreshTokenService;
        _tokenService = tokenService;
    }


    public async Task<IResults> CreateEvent(EventAddRequestDTO model)
    {
        var valResult =
            FluentValidationTool.ValidateModelWithKeyResult<EventAddRequestDTO>(new EventCreateValidator(), model);
        if (valResult.Success == false)
        {
            return new ErrorDataResults<AuthenticatedUserResponseDto>(HttpStatusCode.BadRequest, valResult.Errors);
        }

        var eventModel = _mapper.Map<Event>(model);
        model.StatusId = 0;
        await _eventRepository.AddAsync(eventModel);


        return new SuccessResult();
    }

    public async Task<IDataResults<ICollection<EventToMonthDTO>>> GetListDayByClientId(DateTime date)
    {
        var userId = GetLoggedUserId();

        var query = _eventRepository.Where(x =>
            x.IsDeleted && x.ClientUserId == userId || x.AdminUserId == userId && x.StartDateTime.Month == date.Month);


        var data = _mapper.Map<ICollection<EventToMonthDTO>>(await query.ToListAsync());
        return new SuccessDataResult<ICollection<EventToMonthDTO>>(data, data.Count);
    }


    public async Task<IDataResults<ICollection<EventListClientResponseDto>>> ListEventsByUserId(DateTime date)
    {
        var userId = GetLoggedUserId();
        // && ( x.Date>=date.AddHours(3)&&x.Date<=date.AddDays(1).AddHours(3))
        var eventRepo = _eventRepository.Where(x =>
            !x.IsDeleted && x.ClientUserId == userId || x.AdminUserId == userId && x.StartDateTime.Month == date.Month);
        var eventTypeRepo = _eventTypeRepository.Where(x => !x.IsDeleted);
        var adminRepo = _userRepository.Where(x => !x.IsDeleted);
        var clientRepo = _userRepository.Where(x => !x.IsDeleted);

        var query = from mal in eventRepo
            join eventType in eventTypeRepo on mal.EventTypeId equals eventType.Id into eventTypeUserLeft
            from eventType in eventTypeUserLeft.DefaultIfEmpty()
            join admin in adminRepo on mal.AdminUserId equals admin.Id into adminTypeUserLeft
            from admin in adminTypeUserLeft.DefaultIfEmpty()
            join client in clientRepo on mal.ClientUserId equals client.Id into clientTypeUserLeft
            from client in clientTypeUserLeft.DefaultIfEmpty()
            select new EventListClientResponseDto
            {
                StartDateTime = mal.StartDateTime,
                EndDateTime = mal.EndDateTime,
                Description = mal.Description,
                AdminUserId = mal.AdminUserId,
                ClientUserId = mal.ClientUserId,
                EventTypeDto = new EventTypeDTO()
                {
                    Duration = eventType.Duration,
                    EventName = eventType.Name,
                    Description = eventType.Description,
                    EventTypeId = eventType.Id,
                    Price = eventType.Price
                },
                Admin = new UserDTO()
                {
                    Name = admin.Name,
                    Surname = admin.Surname,
                    Phone = admin.Phone,
                    Id = admin.Id,
                    Address = admin.Address,
                    Mail = admin.Mail
                },
                Client = new UserDTO()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    Phone = client.Phone,
                    Id = client.Id,
                    Address = client.Address,
                    Mail = client.Mail
                },
                StatusId = mal.StatusId,
                Id = mal.Id
            };

        var data = _mapper.Map<ICollection<EventListClientResponseDto>>(await query.ToListAsync());
        return new SuccessDataResult<ICollection<EventListClientResponseDto>>(data, data.Count);
    }

    public async Task<IResults> ChangeEventTime(ChageEventTimeDto eventTime)
    {
        var myEvent = _eventRepository.Where(x => x.Id == eventTime.Id).FirstOrDefault();
        myEvent.StartDateTime = eventTime.StartDateTime;
        myEvent.EndDateTime = eventTime.EndDateTime;
        _eventRepository.Update(myEvent);
        return new SuccessResult();
    }

    public async Task<IDataResults<ICollection<EventListClientResponseDto>>> ListEventsByUserIdByDay(DateTime date)
    {
        var userId = GetLoggedUserId();
        var eventRepo = _eventRepository.Where(x =>
            !x.IsDeleted && (x.ClientUserId == userId || x.AdminUserId == userId) &&
            x.StartDateTime >= date.AddHours(3) && x.EndDateTime <= date.AddDays(1).AddHours(3));
        var eventTypeRepo = _eventTypeRepository.Where(x => !x.IsDeleted);
        var adminRepo = _userRepository.Where(x => !x.IsDeleted);
        var clientRepo = _userRepository.Where(x => !x.IsDeleted);

        var query = from mal in eventRepo
            join eventType in eventTypeRepo on mal.EventTypeId equals eventType.Id into eventTypeUserLeft
            from eventType in eventTypeUserLeft.DefaultIfEmpty()
            join admin in adminRepo on mal.AdminUserId equals admin.Id into adminTypeUserLeft
            from admin in adminTypeUserLeft.DefaultIfEmpty()
            join client in clientRepo on mal.ClientUserId equals client.Id into clientTypeUserLeft
            from client in clientTypeUserLeft.DefaultIfEmpty()
            select new EventListClientResponseDto
            {
                StartDateTime = mal.StartDateTime,
                EndDateTime = mal.EndDateTime,
                Description = mal.Description,
                AdminUserId = mal.AdminUserId,
                ClientUserId = mal.ClientUserId,
                EventTypeDto = new EventTypeDTO()
                {
                    Duration = eventType.Duration,
                    EventName = eventType.Name,
                    Description = eventType.Description,
                    EventTypeId = eventType.Id,
                    Price = eventType.Price
                },
                Admin = new UserDTO()
                {
                    Name = admin.Name,
                    Surname = admin.Surname,
                    Phone = admin.Phone,
                    Id = admin.Id,
                    Address = admin.Address,
                    Mail = admin.Mail
                },
                Client = new UserDTO()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    Phone = client.Phone,
                    Id = client.Id,
                    Address = client.Address,
                    Mail = client.Mail
                },
                StatusId = mal.StatusId,
                Id = mal.Id
            };

        var data = _mapper.Map<ICollection<EventListClientResponseDto>>(await query.ToListAsync());
        return new SuccessDataResult<ICollection<EventListClientResponseDto>>(data, data.Count);
    }


    public async Task<IDataResults<EventByEventId>> EventDetailByEventId(int eventId)
    {
        var eventRepo = _eventRepository.Where(x => x.Id == eventId).FirstOrDefault();
        var eventType = _eventTypeRepository.Where(x => !x.IsDeleted&&x.Id==eventRepo.EventTypeId).FirstOrDefault();
        var client = _userRepository.Where(x => !x.IsDeleted&&eventRepo.ClientUserId==x.Id).FirstOrDefault();

  
      var item    = new EventByEventId
            {
                StartDateTime = eventRepo.StartDateTime,
                EndDateTime = eventRepo.EndDateTime,
                Description = eventRepo.Description,
                AdminUserId = eventRepo.AdminUserId,
                ClientUserId = eventRepo.ClientUserId,
                EventTypeDto = new EventTypeDTO()
                {
                    Duration = eventType.Duration,
                    EventName = eventType.Name,
                    Description = eventType.Description,
                    EventTypeId = eventType.Id,
                    Price = eventType.Price
                },

                Client = new UserDTO()
                {
                    Name = client.Name,
                    Surname = client.Surname,
                    Phone = client.Phone,
                    Id = client.Id,
                    Address = client.Address,
                    Mail = client.Mail
                },
                StatusId = eventRepo.StatusId,
                Id = eventRepo.Id
            };

  
        return new SuccessDataResult<EventByEventId>(item);
    }

    private int? GetLoggedUserId()
    {
        var userRoleString = _loggedUser.FindFirstValue("Id");
        if (int.TryParse(userRoleString, out var userId))
        {
            return userId;
        }

        return null;
    }
}