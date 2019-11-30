using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace StudVoice.DAL
{
    public  class Role : IdentityRole
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
