using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Role
    {
        public Role()
        {
            Userrs = new HashSet<Userr>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<Userr> Userrs { get; set; }
    }
}
