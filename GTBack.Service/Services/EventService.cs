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
using User = Auth0.ManagementApi.Models.User;

namespace GTBack.Service.Services;

public class EventService : IEventService
{
    private readonly IGenericRepository<Event> _eventRepository;
    private readonly IGenericRepository<EventTypeCompanyRelation> _eventTypeCompanyRelationRepository;
    private readonly IGenericRepository<Company> _companyRepository;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly ClaimsPrincipal? _loggedUser;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IValidatorFactory _validatorFactory;
    private readonly IJwtTokenService _tokenService;

    public EventService(IGenericRepository<Event> eventRepository,
        IGenericRepository<EventTypeCompanyRelation> eventTypeCompanyRelationRepository,
        IGenericRepository<Company> companyRepository,
        IRefreshTokenService refreshTokenService, IJwtTokenService tokenService,
        IValidatorFactory validatorFactory, IHttpContextAccessor httpContextAccessor, IService<Event> service,
        IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _eventRepository = eventRepository;
        _companyRepository = companyRepository;
        _eventTypeCompanyRelationRepository = eventTypeCompanyRelationRepository;
        _loggedUser = httpContextAccessor.HttpContext?.User;
        _validatorFactory = validatorFactory;
        _refreshTokenService = refreshTokenService;
        _tokenService = tokenService;
    }


    public async Task<IResults> createEvent(EventAddRequestDTO model)
    {
        var valResult =
            FluentValidationTool.ValidateModelWithKeyResult<EventAddRequestDTO>(new EventCreateValidator(), model);
        if (valResult.Success == false)
        {
            return new ErrorDataResults<AuthenticatedUserResponseDto>(HttpStatusCode.BadRequest, valResult.Errors);
        }

        var eventModel = _mapper.Map<Event>(model);

        await _eventRepository.AddAsync(eventModel);

        await _unitOfWork.CommitAsync();

        return new SuccessResult();
    }

    public async Task<IDataResults<ICollection<EventListClientResponseDto>>> GetListByClientId()
    {
        var userId = GetLoggedUserId();

        var query = _eventRepository.Where(x => !x.IsDeleted && x.ClientUserId == userId || x.AdminUserId == userId);

        var data = _mapper.Map<ICollection<EventListClientResponseDto>>(await query.ToListAsync());

        return new SuccessDataResult<ICollection<EventListClientResponseDto>>(data, data.Count);
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