using System;
using System.Collections.Generic;
using StudVoice.DAL.Models.Entities.Abstractions;

namespace StudVoice.DAL
{
    public  class Lesson : IBaseEntity, IAuditableEntity
    {
        public Lesson()
        {
            LessonFeedbacks = new HashSet<LessonFeedback>();
        }

        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<LessonFeedback> LessonFeedbacks { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
    }
}
