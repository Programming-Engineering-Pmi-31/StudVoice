using System;
using System.Collections.Generic;

namespace StudVoice
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

        public ICollection<Users> Users { get; set; }
    }
}
