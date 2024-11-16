using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Website
    {
        public Website()
        {
            Bankaccounts = new HashSet<Bankaccount>();
        }

        public decimal Websiteid { get; set; }

        public virtual WebsiteBalance? WebsiteBalance { get; set; }
        public virtual ICollection<Bankaccount> Bankaccounts { get; set; }
    }
}
