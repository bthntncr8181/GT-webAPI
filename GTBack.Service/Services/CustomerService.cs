using AutoMapper;
using FluentValidation;
using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Enums;
using GTBack.Core.Models;
using GTBack.Core.Results;
using GTBack.Core.Services;
using GTBack.Core.UnitOfWorks;
using GTBack.Service.Utilities;
using GTBack.Service.Utilities.Jwt;
using GTBack.Service.Validation;
using GTBack.Service.Validation.Tool;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;

namespace GTBack.Service.Services
{
    public class CustomerService:ICustomerService
    {



        private readonly IService<Customer> _service;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly ClaimsPrincipal? _loggedUser;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidatorFactory _validatorFactory;
        private readonly IJwtTokenService _tokenService;

        public CustomerService(IRefreshTokenService refreshTokenService,IJwtTokenService tokenService, IValidatorFactory validatorFactory,IHttpContextAccessor httpContextAccessor, IService<Customer> service, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _service = service;
            _loggedUser= httpContextAccessor.HttpContext?.User;
            _validatorFactory = validatorFactory;
            _refreshTokenService= refreshTokenService;
            _tokenService= tokenService;
        }

     

      
      
        public async Task<IDataResults<CustomerDto>> GetById(int id)
        {
            var place = await _service.GetByIdAsync(x => x.Id == id);
            var data = _mapper.Map<CustomerDto>(place);
            return new SuccessDataResult<CustomerDto>(data);
        }
        public async Task<IResults> Put(UpdateCustomer entiti)
        {
            var place = await _service.GetByIdAsync(x => x.Id == entiti.Id);
            var place2 = _mapper.Map<Customer>(entiti);

            place2.PasswordHash = place.PasswordHash;
            await _service.UpdateAsync(place2);
            return new SuccessResult();
        }
        public async Task<IResults> Delete(int id)
        {
            var place = await _service.GetByIdAsync(x => x.Id == id);
            place.IsDeleted = true;
            await _service.UpdateAsync(place);
            return new SuccessResult();
        }
        public async Task<IDataResults<AuthenticatedUserResponseDto>>Register(CustomerDto registerDto)
        {

            var valResult = FluentValidationTool.ValidateModelWithKeyResult<CustomerDto>(new CustomerDtoValidator(), registerDto);
            if (valResult.Success == false)
            {
                return new ErrorDataResults<AuthenticatedUserResponseDto>(HttpStatusCode.BadRequest, valResult.Errors);
            }

            var username = registerDto.UserName.ToLower().Trim();
            var mail = registerDto.Mail.ToLower().Trim();
            var user = await _service.GetByIdAsync((x => x.Username.ToLower() == username && !x.IsDeleted));//get by mail eklenecek
            var user2 = await _service.GetByIdAsync((x => x.Mail.ToLower() == mail && !x.IsDeleted));//get by mail eklenecek

            if (user!=null)
            {
                valResult.Errors.Add("", Messages.User_Username_Exist);
                return new ErrorDataResults<AuthenticatedUserResponseDto>(HttpStatusCode.BadRequest, valResult.Errors);
            }
            else if (user2!=null)
            {
                valResult.Errors.Add("", Messages.User_Email_Exists);
                return new ErrorDataResults<AuthenticatedUserResponseDto>(HttpStatusCode.BadRequest, valResult.Errors);
            }



            user = new Customer()
            {
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Mail = registerDto.Mail,
                Username=registerDto.UserName,
                Surname = registerDto.Surname,
                IsDeleted = false,
                Name = registerDto.Name,
                PasswordHash = SHA1.Generate(registerDto.password)
            };

            await _service.AddAsync(user);
            await _unitOfWork.CommitAsync();

            var response = await Authenticate(_mapper.Map<CustomerDto>(user));
            return new SuccessDataResult<AuthenticatedUserResponseDto>(response, HttpStatusCode.OK);
        }


        public async Task<IDataResults<ICollection<CustomerDto>>> List(CustomerListParameters parameters)
        {
            var query = _service
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


            if (parameters.customerId.HasValue)
            {
                query = query.Where(x => x.Id == parameters.customerId.Value);
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
            if (parameters.Search != null)
            {
                query = query.Where(x => x.Name == parameters.Search);
            }
           
            var data = _mapper.Map<ICollection<CustomerDto>>(await query.ToListAsync());
            return new SuccessDataResult<ICollection<CustomerDto>>(data, totalCount);
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
        public async Task<IDataResults<CustomerDto>> Me()
        {
            var userId = GetLoggedUserId();
        
            CustomerDto? user = null;
           
               
                    var teacherEntity = await _service.FindAsNoTrackingAsync(x => !x.IsDeleted && x.Id == userId);
                    user = _mapper.Map<CustomerDto>(teacherEntity);
                  
              
            if (user == null)
            {
                return new ErrorDataResults<CustomerDto>(Messages.User_NotFound_Message, HttpStatusCode.NotFound);
            }

            return new SuccessDataResult<CustomerDto>(user);
        }
        public async Task<IResults> Login(LoginDto loginDto)
        {
           //  var valResult = FluentValidationTool.ValidateModelWithKeyResult(_validatorFactory.GetValidator<LoginDto>(), loginDto);
           //  if (valResult.Success == false)
           //  {
           //      return new ErrorDataResults<AuthenticatedUserResponseDto>( HttpStatusCode.BadRequest,valResult.Errors);
           //  }
           // var  username = loginDto.UserName.ToLower().Trim();
           //  var parent = await _service.GetByIdAsync((x => x.Username.ToLower() == username && !x.IsDeleted));//get by mail eklenecek
           //
           //
           //  if (parent?.PasswordHash == null)
           //  {
           //      valResult.Errors.Add("", Messages.User_NotFound_Message);
           //      return new ErrorDataResults<AuthenticatedUserResponseDto>(Messages.User_NotFound_Message, HttpStatusCode.BadRequest);
           //  }
           //  if (!Utilities.SHA1.Verify(loginDto.password, parent.PasswordHash))
           //  {
           //      valResult.Errors.Add("", Messages.User_Login_Message_Notvalid);
           //      return new ErrorDataResults<AuthenticatedUserResponseDto>(Messages.Password_Wrong, HttpStatusCode.BadRequest);
           //  }
           //  parent.UpdatedDate = DateTime.UtcNow;
           //  await _unitOfWork.CommitAsync();
           //  var response = await Authenticate(_mapper.Map<CustomerDto>(parent));
            return new SuccessResult();
        }

        private async Task<AuthenticatedUserResponseDto> Authenticate(CustomerDto userDto)
        {
            var accessToken = _tokenService.GenerateAccessToken(userDto);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var refreshTokenDto = new RefreshTokenDto()
            {
                Token = refreshToken,
              
            };
            await _refreshTokenService.Create(refreshTokenDto);

            return new AuthenticatedUserResponseDto()
            {
                AccessToken = accessToken.Value,
                AccessTokenExpirationTime = accessToken.ExpirationTime,
                RefreshToken = refreshToken
            };
        }

      
    }
}
