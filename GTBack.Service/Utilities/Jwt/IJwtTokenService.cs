using GTBack.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTBack.Core.DTO.Restourant.Request;
using GTBack.Core.Entities;

namespace GTBack.Service.Utilities.Jwt
{
    public interface IJwtTokenService
    {
        public AccessTokenDto GenerateAccessToken(UserRegisterDTO userDto);
        public AccessTokenDto GenerateAccessTokenRestourant(ClientRegisterRequestDTO userDto);
        public string GenerateRefreshToken();
        public bool Validate(string refreshToken);
    }
}
