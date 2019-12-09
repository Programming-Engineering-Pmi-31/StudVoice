using AutoMapper;
using StudVoice.BLL.DTOs;
using StudVoice.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.Mappings
{
    public class TeacherProfile :Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDTO>()
                .ForMember(t => t.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Lessons, opt => opt.MapFrom(t => t.Lessons))
                .ForMember(t => t.TeacherFeedBacks, opt => opt.MapFrom(t => t.TeacherFeedbacks));

            CreateMap<TeacherDTO, Teacher>()
                .ForMember(t => t.Id, opt => opt.MapFrom(t => t.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Lessons, opt => opt.MapFrom(t => t.Lessons))
                .ForMember(t => t.TeacherFeedbacks, opt => opt.MapFrom(t => t.TeacherFeedBacks));
        }
    }
}
