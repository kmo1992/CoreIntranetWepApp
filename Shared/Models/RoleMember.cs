using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public partial class RoleMember
    {
        public short RoleId { get; set; }
        public int AdUserId { get; set; }

        public virtual AdUser AdUser { get; set; }
        public virtual Role Role { get; set; }
    }
}
