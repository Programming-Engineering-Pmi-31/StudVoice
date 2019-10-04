using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using StudVoice.DAL.Models.Entities.Abstractions;


namespace StudVoice.DAL
{
    public  class User : IdentityUser, IAuditableEntity
    {
        public User()
        {
            Teachers = new HashSet<Teacher>();
            UserRoles = new HashSet<UserRole>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int? ContactId { get; set; }
        public int? FacultyId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
