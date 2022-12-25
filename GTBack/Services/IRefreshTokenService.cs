using GTBack.Core.DTO;
using GTBack.Core.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTBack.Core.Services
{
    public interface IRefreshTokenService
    {

        Task<RefreshToken?> GetByToken(string token);

        Task Create(RefreshTokenDto refreshTokenDto);

        Task Delete(Guid id);

        Task DeleteAll(int userId);
    }
}
