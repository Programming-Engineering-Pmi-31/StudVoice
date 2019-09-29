using System;
using System.Collections.Generic;

namespace StudVoice
{
    public partial class Faculties
    {
        public Faculties()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
