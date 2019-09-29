using System;
using System.Collections.Generic;

namespace StudVoice
{
    public partial class Lessons
    {
        public Lessons()
        {
            LessonFeedbacks = new HashSet<LessonFeedbacks>();
        }

        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string Name { get; set; }

        public Teachers Teacher { get; set; }
        public ICollection<LessonFeedbacks> LessonFeedbacks { get; set; }
    }
}
