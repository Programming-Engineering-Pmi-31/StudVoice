using System;
using Microsoft.Extensions.DependencyInjection;
using StudVoice.BLL.Services.Interfaces;

namespace StudVoice.BLL.Factories
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private IAuthenticationService _authenticationService;
        private IUserService _userService;
        private ITeacherService _teacherService;
        private ILessonService _lessonService;
        private ITeacherFeedbackService _teacherFeedbackService;
        private ILessonFeedbackService _lessonFeedbackService;

        public ServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAuthenticationService AuthenticationService => _authenticationService ?? (_authenticationService = _serviceProvider.GetService<IAuthenticationService>());

        public IUserService UserService => _userService ?? (_userService = _serviceProvider.GetService<IUserService>());

        public ITeacherService TeacherService => _teacherService ?? (_teacherService = _serviceProvider.GetService<ITeacherService>());

        public ILessonService LessonService => _lessonService ?? (_lessonService = _serviceProvider.GetService<ILessonService>());

        public ILessonFeedbackService LessonFeedbackService => _lessonFeedbackService ?? (_lessonFeedbackService = _serviceProvider.GetService<ILessonFeedbackService>());

        public ITeacherFeedbackService TeacherFeedbackService => _teacherFeedbackService ?? (_teacherFeedbackService = _serviceProvider.GetService<ITeacherFeedbackService>());
    }
}