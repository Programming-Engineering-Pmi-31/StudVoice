using System;
using System.Collections.Generic;

namespace StudVoice
{
    public partial class LessonFeedbacks
    {
        public int Id { get; set; }
        public int? LessonId { get; set; }
        public string Feedback { get; set; }
        public int? Point { get; set; }

        public Lessons Lesson { get; set; }
    }
}
