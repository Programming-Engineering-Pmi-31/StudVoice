using System;
using System.Collections.Generic;
using StudVoice.DAL.Models.Entities.Abstractions;

namespace StudVoice.DAL
{
    public class Contact : IBaseEntity, IAuditableEntity
    {
        public Contact()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual User Create { get; set; }
        public virtual User Mod { get; set; }
    }
}
