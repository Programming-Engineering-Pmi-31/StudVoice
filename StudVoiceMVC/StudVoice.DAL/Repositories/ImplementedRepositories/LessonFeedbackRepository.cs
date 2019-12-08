using StudVoice.DAL.Repositories.InterfacesRepositories;

namespace StudVoice.DAL.Repositories.ImplementedRepositories
{
    public class LessonFeedbackRepository : BaseRepository<LessonFeedback>, ILessonFeedbackRepository
    {
        public LessonFeedbackRepository(StudVoiceDBContext context) : base(context)
        {
        }
    }
}