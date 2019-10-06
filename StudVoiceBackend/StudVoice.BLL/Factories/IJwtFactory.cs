using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using StudVoice.BLL.DTOs;

namespace StudVoice.BLL.Factories
{
    public interface IJwtFactory
    {
        (ClaimsPrincipal principal, JwtSecurityToken jwt) GetPrincipalFromExpiredToken(string token);
        TokenDTO GenerateToken(string userId, string login, string role);
    }
}