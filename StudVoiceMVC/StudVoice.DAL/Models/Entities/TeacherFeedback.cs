using System;
using StudVoice.DAL.Models.Entities.Abstractions;

namespace StudVoice.DAL
{
    public  class TeacherFeedback : IBaseEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public string Feedback { get; set; }
        public int? Point { get; set; }

        public virtual Teacher Teacher { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
    }
}
