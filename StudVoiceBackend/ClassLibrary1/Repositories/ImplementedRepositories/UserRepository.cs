using StudVoice.DAL.Repositories.InterfacesRepositories;

namespace StudVoice.DAL.Repositories.ImplementedRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StudVoiceDBContext _dbContext;

        public UserRepository(StudVoiceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CurrentUserId
        {
            get => _dbContext.CurrentUserId;
            set => _dbContext.CurrentUserId = value;
        }
    }
}