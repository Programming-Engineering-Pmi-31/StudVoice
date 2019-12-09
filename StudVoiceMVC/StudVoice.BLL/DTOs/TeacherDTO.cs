using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<LessonDTO> Lessons { get; set; }
        public ICollection<TeacherFeedbackDTO> TeacherFeedBacks { get; set; }
        public Byte[] QrCode { get; set; }
    }
}
