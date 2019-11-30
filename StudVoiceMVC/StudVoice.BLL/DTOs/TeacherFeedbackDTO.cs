using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class TeacherFeedbackDTO
    {
        public int TeacherId { get; set;}
        public string Feedback { get; set; }
        public int Point { get; set; }
    }
}
