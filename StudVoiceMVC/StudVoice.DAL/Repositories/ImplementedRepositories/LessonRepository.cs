using Microsoft.EntityFrameworkCore;
using StudVoice.DAL.Repositories.InterfacesRepositories;
using System.Linq;
using System.Threading.Tasks;

namespace StudVoice.DAL.Repositories.ImplementedRepositories
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(StudVoiceDBContext context) : base(context)
        {

        }
        public override Task<Lesson> GetByIdAsync(int id)
        {
            return ComplexEntities.SingleOrDefaultAsync(entity => entity.Id == id);
        }

        protected override IQueryable<Lesson> ComplexEntities => base.Entities
            .Include(t => t.LessonFeedbacks);
    }
}