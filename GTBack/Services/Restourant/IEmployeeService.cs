using GTBack.Core.DTO;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Results;

namespace GTBack.Core.Services.Restourant;

public interface IEmployeeService
{
 
    // Task<IDataResults<EmployeeDTO>> GetById(int id);
    Task<IDataResults<AuthenticatedUserResponseDto>> Login(LoginDto loginDto);
    // Task<IDataResults<AuthenticatedUserResponseDto>> PasswordChoose(PasowrdConfirmDTO loginDto);
    Task<IResults> Register(EmployeeRegisterDTO registerDto);
}