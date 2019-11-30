using System;
using System.Collections.Generic;

namespace StudVoiceMVC
{
    public partial class LessonFeedbacks
    {
        public int Id { get; set; }
        public int? LessonId { get; set; }
        public string Feedback { get; set; }
        public int? Point { get; set; }

        public virtual Lessons Lesson { get; set; }
    }
}
