using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class LessonFeedbackDTO
    {
        public int LessonId { get; set;}
        public string FeedBack { get; set;}
        public int Point { get; set; }
    }
}
