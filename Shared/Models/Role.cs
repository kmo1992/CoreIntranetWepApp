using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleMember = new HashSet<RoleMember>();
        }

        public short RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<RoleMember> RoleMember { get; set; }
    }
}
