using System;
using System.Collections.Generic;

namespace StudVoiceMVC
{
    public partial class TeacherFeedbacks
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string Feedback { get; set; }
        public int? Point { get; set; }

        public virtual Teachers Teacher { get; set; }
    }
}
