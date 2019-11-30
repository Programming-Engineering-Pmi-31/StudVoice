﻿using System;
using System.Collections.Generic;

namespace StudVoiceMVC
{
    public partial class UserRoles
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
