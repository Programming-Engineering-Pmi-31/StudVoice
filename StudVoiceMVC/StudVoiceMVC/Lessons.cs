using System;
using System.Collections.Generic;

namespace StudVoiceMVC
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

        public virtual Teachers Teacher { get; set; }
        public virtual ICollection<LessonFeedbacks> LessonFeedbacks { get; set; }
    }
}
