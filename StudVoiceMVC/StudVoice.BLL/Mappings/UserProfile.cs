using System.Linq;
using AutoMapper;
using StudVoice.BLL.DTOs;
using StudVoice.DAL;

namespace StudVoice.BLL.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<UserDTO, User>()
                .ForMember(u => u.UpdatedById, opt => opt.Ignore())
                .ForMember(u => u.CreatedById, opt => opt.Ignore())
                .ForMember(u => u.UpdatedDate, opt => opt.Ignore())
                .ForMember(u => u.CreatedDate, opt => opt.Ignore())

                .ForMember(u => u.ContactMod, opt => opt.Ignore())
                .ForMember(u => u.ContactCreate, opt => opt.Ignore())
                .ForMember(u => u.FacultyMod, opt => opt.Ignore())
                .ForMember(u => u.FacultyCreate, opt => opt.Ignore())
                .ForMember(u => u.LessonMod, opt => opt.Ignore())
                .ForMember(u => u.LessonCreate, opt => opt.Ignore())
                .ForMember(u => u.LessonFeedbackMod, opt => opt.Ignore())
                .ForMember(u => u.LessonFeedbackCreate, opt => opt.Ignore())
                .ForMember(u => u.TeacherMod, opt => opt.Ignore())
                .ForMember(u => u.TeacherCreate, opt => opt.Ignore())
                .ForMember(u => u.TeacherFeedbackMod, opt => opt.Ignore())
                .ForMember(u => u.TeacherFeedbackCreate, opt => opt.Ignore());
            CreateMap<User, UserDTO>()
                .ForMember(u => u.Password, opt => opt.Ignore())
                .ForMember(u => u.Role, opt => opt.MapFrom(u => u.UserRoles.FirstOrDefault().Role));
        }

    }
}