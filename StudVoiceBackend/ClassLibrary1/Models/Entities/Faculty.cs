using System;
using System.Collections.Generic;
using StudVoice.DAL.Models.Entities.Abstractions;

namespace StudVoice.DAL
{
    public  class Faculty : IBaseEntity, IAuditableEntity
    {
        public Faculty()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
    }
}
