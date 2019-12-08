using System;
using System.Collections.Generic;

namespace StudVoice
{
    public partial class UserRoles
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public Roles Role { get; set; }
        public Users User { get; set; }
    }
}
