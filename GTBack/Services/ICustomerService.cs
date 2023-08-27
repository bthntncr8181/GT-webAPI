using GTBack.Core.DTO;
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

  

        Task<IDataResults<CustomerDto>> GetById(int id);

        Task<IResults> Put(UpdateCustomer place);
        Task<IDataResults<CustomerDto>> Me();
        int? GetLoggedUserId();
        Task<IResults> Login();
        Task<IResults> Delete(int id);

        Task<IDataResults<AuthenticatedUserResponseDto>> Register(CustomerDto registerDto);



    }
}
