using System;
using System.Collections.Generic;
using AutoMapper;
using System.Text;
using StudVoice.BLL.DTOs;
using StudVoice.DAL;

namespace StudVoice.BLL.Mappings
{
    public class LessonFeedbackProfile:Profile
    {
        public LessonFeedbackProfile()
        {
            CreateMap<LessonFeedback, LessonFeedbackDTO>()
                .ForMember(t => t.LessonId, opt => opt.MapFrom(t => t.LessonId))
                .ForMember(t => t.FeedBack, opt => opt.MapFrom(t => t.Feedback))
                .ForMember(t => t.Point, opt => opt.MapFrom(t => t.Point));

            CreateMap<LessonFeedbackDTO, LessonFeedback>()
                .ForMember(t => t.LessonId, opt => opt.MapFrom(t => t.LessonId))
                .ForMember(t => t.Feedback, opt => opt.MapFrom(t => t.FeedBack))
                .ForMember(t => t.Point, opt => opt.MapFrom(t => t.Point));
        }
    }
}
