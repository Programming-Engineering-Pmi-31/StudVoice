using System;
using System.Collections.Generic;

namespace StudVoiceMVC
{
    public partial class Contacts
    {
        public Contacts()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
