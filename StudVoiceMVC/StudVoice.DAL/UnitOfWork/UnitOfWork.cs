using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StudVoice.DAL.Repositories.InterfacesRepositories;

namespace StudVoice.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StudVoiceDBContext _context;

        private readonly IServiceProvider _serviceProvider;

        private IContactRepository _contactRepository;

        private IFacultyRepository _facultyRepository;

        private ILessonRepository _lessonRepository;

        private ILessonFeedbackRepository _lessonFeedbackRepository;

        private ITeacherRepository _teacherRepository;

        private ITeacherFeedbackRepository _teacherFeedbackRepository;

        private IUserRepository _userRepository;

        private UserManager<User> _userManager;

        private RoleManager<Role> _roleManager;

        public UnitOfWork()
        {
        }

        public UnitOfWork(StudVoiceDBContext context,
            IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public IContactRepository ContactRepository => 
            _contactRepository ?? (_contactRepository = _serviceProvider.GetService<IContactRepository>());
        public IFacultyRepository FacultyRepository =>
            _facultyRepository ?? (_facultyRepository = _serviceProvider.GetService<IFacultyRepository>());
        public ILessonRepository LessonRepository =>
            _lessonRepository ?? (_lessonRepository = _serviceProvider.GetService<ILessonRepository>());
        public ILessonFeedbackRepository LessonFeedbackRepository =>
            _lessonFeedbackRepository ?? (_lessonFeedbackRepository = _serviceProvider.GetService<ILessonFeedbackRepository>());
        public ITeacherRepository TeacherRepository =>
            _teacherRepository ?? (_teacherRepository = _serviceProvider.GetService<ITeacherRepository>());
        public ITeacherFeedbackRepository TeacherFeedback =>
            _teacherFeedbackRepository ?? (_teacherFeedbackRepository = _serviceProvider.GetService<ITeacherFeedbackRepository>());
        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository = _serviceProvider.GetService<IUserRepository>());
        public UserManager<User> UserManager =>
            _userManager ?? (_userManager = _serviceProvider.GetService<UserManager<User>>());
        public RoleManager<Role> RoleManager =>
            _roleManager ?? (_roleManager = _serviceProvider.GetService<RoleManager<Role>>());

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}