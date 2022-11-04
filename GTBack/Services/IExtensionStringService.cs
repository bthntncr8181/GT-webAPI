using GTBack.Core.DTO;
using GTBack.Core.Entities;
using GTBack.Core.Results;
using GTBack.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Services
{
    public interface IExtensionStringService
    {

    

        Task<IDataResults<ExtensionDto>> GetById(int id);

        Task<IResults> Put(ExtensionDto place);


        Task<IResults> Delete(int id);

        Task<IDataResults<ExtensionDto>> Add(ExtensionDto registerDto);
    }
}
