using AutoMapper;
using StudVoice.BLL.DTOs;
using StudVoice.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.Mappings
{
    public class TeacherFeedbackProfile : Profile
    {
        public TeacherFeedbackProfile()
        {
            CreateMap<TeacherFeedback, TeacherFeedbackDTO>()
                .ForMember(t => t.TeacherId, opt => opt.MapFrom(t => t.TeacherId))
                .ForMember(t => t.Feedback, opt => opt.MapFrom(t => t.Feedback))
                .ForMember(t => t.Point, opt => opt.MapFrom(t => t.Point));

            CreateMap<TeacherFeedbackDTO, TeacherFeedback>()
                .ForMember(t => t.TeacherId, opt => opt.MapFrom(t => t.TeacherId))
                .ForMember(t => t.Feedback, opt => opt.MapFrom(t => t.Feedback))
                .ForMember(t => t.Point, opt => opt.MapFrom(t => t.Point));
        }
    }    
}
