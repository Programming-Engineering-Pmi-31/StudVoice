using System;
using System.Collections.Generic;

namespace StudVoiceMVC
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

        public virtual Users User { get; set; }
        public virtual ICollection<Lessons> Lessons { get; set; }
        public virtual ICollection<TeacherFeedbacks> TeacherFeedbacks { get; set; }
    }
}
