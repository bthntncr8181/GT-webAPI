using GTBack.Core.DTO;
using GTBack.Core.Results;
using GTBack.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Services
{
    public interface IPlaceService
    {
        Task<IDataResults<ICollection<PlaceDto>>> List(PlaceListParameters parameters);
    }
}
