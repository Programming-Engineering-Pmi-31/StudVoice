using System;
using System.Collections.Generic;

namespace StudVoice
{
    public partial class Teachers
    {
        public Teachers()
        {
            Lessons = new HashSet<Lessons>();
            TeacherFeedbacks = new HashSet<TeacherFeedbacks>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public Users User { get; set; }
        public ICollection<Lessons> Lessons { get; set; }
        public ICollection<TeacherFeedbacks> TeacherFeedbacks { get; set; }
    }
}
