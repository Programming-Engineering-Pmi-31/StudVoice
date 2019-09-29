using System;
using System.Collections.Generic;

namespace StudVoice
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

        public Contacts Contact { get; set; }
        public Faculties Faculty { get; set; }
        public ICollection<Teachers> Teachers { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
