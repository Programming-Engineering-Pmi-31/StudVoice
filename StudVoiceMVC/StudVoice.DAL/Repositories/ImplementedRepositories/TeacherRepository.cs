using Microsoft.EntityFrameworkCore;
using StudVoice.DAL.Repositories.InterfacesRepositories;
using System.Linq;
using System.Threading.Tasks;

namespace StudVoice.DAL.Repositories.ImplementedRepositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(StudVoiceDBContext context) : base(context)
        {
           
        }   
        public override Task<Teacher> GetByIdAsync(int id)
        {
            return ComplexEntities.SingleOrDefaultAsync(entity => entity.Id == id);
            
        }

        protected override IQueryable<Teacher> ComplexEntities => base.Entities
            .Include(t => t.TeacherFeedbacks)
            .Include(t => t.Lessons).ThenInclude(t=>t.LessonFeedbacks);

    }
}