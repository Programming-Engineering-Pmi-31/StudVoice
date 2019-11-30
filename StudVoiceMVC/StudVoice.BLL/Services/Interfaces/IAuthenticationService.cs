using System.Threading.Tasks;
using StudVoice.BLL.DTOs;

namespace StudVoice.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<TokenDTO> SignInAsync(LoginDTO credentials);

        Task<TokenDTO> TokenAsync(TokenDTO token);
    }
}