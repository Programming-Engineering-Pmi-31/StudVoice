using StudVoice.BLL.Services.Interfaces;

namespace StudVoice.BLL.Factories
{
    public interface IServiceFactory
    {
        IAuthenticationService AuthenticationService { get; }
        ILessonService LessonService { get; }
        ITeacherService TeacherService { get; }
        IUserService UserService { get; }
        ITeacherFeedbackService TeacherFeedbackService { get; }
        ILessonFeedbackService LessonFeedbackService { get; }
    }
}