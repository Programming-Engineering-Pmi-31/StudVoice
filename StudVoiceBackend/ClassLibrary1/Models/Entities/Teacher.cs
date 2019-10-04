using System;
using System.Collections.Generic;
using StudVoice.DAL.Models.Entities.Abstractions;

namespace StudVoice.DAL
{
    public  class Teacher : IBaseEntity, IAuditableEntity
    {
        public Teacher()
        {
            Lessons = new HashSet<Lesson>();
            TeacherFeedbacks = new HashSet<TeacherFeedback>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<TeacherFeedback> TeacherFeedbacks { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
