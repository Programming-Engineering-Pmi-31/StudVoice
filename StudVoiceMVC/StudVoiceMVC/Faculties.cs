using System;
using System.Collections.Generic;

namespace StudVoiceMVC
{
    public partial class Faculties
    {
        public Faculties()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
