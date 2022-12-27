using GTBack.Core.DTO.Request;
using GTBack.Core.DTO.Response;
using GTBack.Core.Entities.Constants;
using GTBack.Core.Models;
using GTBack.Core.Results;
using GTBack.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Services
{
    public interface ICustomerService
    {
        Task<IDataResults<ICollection<CustomerDto>>> List(CustomerListParameters parameters);
        Task<IDataResults<ICollection<iller>>> getsehir(string name);
        Task<IDataResults<InteractionDto>> Interaction(InteractionDto inter);

        Task<IDataResults<ICollection<ilceler>>> getilce(string name, int sehirid);


        Task<IDataResults<List<PlaceResponseDto>>> CustomerHasPlace(PlaceListParameters parameters);

        Task<IDataResults<CustomerDto>> GetById(int id);
        Task<IResults> EmailSearch(string mail);
        Task<IResults> UsernameSearch(string mail);

        Task<IResults> Put(UpdateCustomer place);
        Task<IDataResults<CustomerDto>> Me();
        int? GetLoggedUserId();
        Task<IDataResults<AuthenticatedUserResponseDto>> Login(LoginDto loginDto);
        Task<IResults> Delete(int id);

        Task<IDataResults<AuthenticatedUserResponseDto>> Register(CustomerDto registerDto);



    }
}
