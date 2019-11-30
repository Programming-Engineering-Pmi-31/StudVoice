using AutoMapper;
using StudVoice.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class TeacherProfile :Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDTO>()
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Lessons, opt => opt.MapFrom(t => t.Lessons))
                .ForMember(t => t.TeacherFeedBacks, opt => opt.MapFrom(t => t.TeacherFeedbacks))
                .ForMember(t => t.Id, opt => opt.MapFrom(t => t.Id));

            CreateMap<TeacherDTO, Teacher>()
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Lessons, opt => opt.MapFrom(t => t.Lessons))
                .ForMember(t => t.TeacherFeedbacks, opt => opt.MapFrom(t => t.TeacherFeedBacks))
                .ForMember(t => t.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
