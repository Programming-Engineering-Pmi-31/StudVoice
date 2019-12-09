using System;
using System.Collections.Generic;
using System.Text;

namespace StudVoice.BLL.DTOs
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public ICollection<LessonFeedbackDTO> LessonFeedbacks { get; set; }
        public Byte[] QrCode { get; set; }
    }
}
