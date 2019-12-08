using StudVoice.DAL.Repositories.InterfacesRepositories;

namespace StudVoice.DAL.Repositories.ImplementedRepositories
{
    public class TeacherFeedbackRepository : BaseRepository<TeacherFeedback>, ITeacherFeedbackRepository
    {
        public TeacherFeedbackRepository(StudVoiceDBContext context) : base(context)
        {
        }
    }
}