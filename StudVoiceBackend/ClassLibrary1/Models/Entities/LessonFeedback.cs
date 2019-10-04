using System;
using System.Collections.Generic;
using StudVoice.DAL.Models.Entities.Abstractions;

namespace StudVoice.DAL
{
    public  class LessonFeedback : IBaseEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public int? LessonId { get; set; }
        public string Feedback { get; set; }
        public int? Point { get; set; }

        public virtual Lesson Lesson { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
    }
}
