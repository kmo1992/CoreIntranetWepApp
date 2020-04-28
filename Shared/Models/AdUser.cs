using System;
using System.Collections.Generic;

namespace Shared.Models
{
    public partial class AdUser
    {
        public AdUser()
        {
            RoleMember = new HashSet<RoleMember>();
        }

        public int AdUserId { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<RoleMember> RoleMember { get; set; }
    }
}
