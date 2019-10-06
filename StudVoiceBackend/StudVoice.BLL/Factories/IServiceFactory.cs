using StudVoice.BLL.Services.Interfaces;

namespace StudVoice.BLL.Factories
{
    public interface IServiceFactory
    {
        IAuthenticationService AuthenticationService { get; }

        IUserService UserService { get; }
    }
}