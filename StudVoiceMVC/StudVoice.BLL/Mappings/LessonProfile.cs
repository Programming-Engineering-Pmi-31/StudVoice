using AutoMapper;
using StudVoice.BLL.DTOs;
using StudVoice.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.Mappings
{
    public class LessonProfile: Profile
    {
        public LessonProfile()
        {
            CreateMap<Lesson, LessonDTO>()
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Theme, opt => opt.MapFrom(t => t.Theme))
                .ForMember(t => t.Description, opt => opt.MapFrom(t => t.Description))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(t => t.DateTime))
                .ForMember(t => t.LessonFeedbacks, opt => opt.MapFrom(t => t.LessonFeedbacks));

            CreateMap<LessonDTO, Lesson>()
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Name))
                .ForMember(t => t.Theme, opt => opt.MapFrom(t => t.Theme))
                .ForMember(t => t.Description, opt => opt.MapFrom(t => t.Description))
                .ForMember(t => t.DateTime, opt => opt.MapFrom(t => t.DateTime))
                .ForMember(t => t.LessonFeedbacks, opt => opt.MapFrom(t => t.LessonFeedbacks));
        }
    }
}
