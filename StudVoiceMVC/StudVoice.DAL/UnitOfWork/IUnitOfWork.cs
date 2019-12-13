using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StudVoice.DAL.Repositories.InterfacesRepositories;

namespace StudVoice.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IContactRepository ContactRepository { get; }
        IFacultyRepository FacultyRepository { get; }
        ILessonRepository LessonRepository { get; }
        ILessonFeedbackRepository LessonFeedbackRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ITeacherFeedbackRepository TeacherFeedbackRepository { get; }
        IUserRepository UserRepository { get; }
        UserManager<User> UserManager { get; }
        RoleManager<Role> RoleManager { get; }
        Task<int> SaveAsync();
    }
}