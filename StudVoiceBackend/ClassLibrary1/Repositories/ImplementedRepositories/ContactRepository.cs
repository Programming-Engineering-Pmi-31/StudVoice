using StudVoice.DAL.Repositories.InterfacesRepositories;

namespace StudVoice.DAL.Repositories.ImplementedRepositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(StudVoiceDBContext context) : base(context)
        {
        }
    }
}