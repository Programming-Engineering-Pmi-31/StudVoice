using System;
using System.Collections.Generic;

namespace StudVoiceMVC
{
    public partial class Users
    {
        public Users()
        {
            Teachers = new HashSet<Teachers>();
            UserRoles = new HashSet<UserRoles>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int? ContactId { get; set; }
        public int? FacultyId { get; set; }
        public string Password { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual Faculties Faculty { get; set; }
        public virtual ICollection<Teachers> Teachers { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
