using System.Collections.Generic;

namespace StudVoice.DAL.Repositories.InterfacesRepositories
{
    public interface IUserRepository
    {
        string CurrentUserId { get; set; }
        IEnumerable<User> GetAll();
    }
}