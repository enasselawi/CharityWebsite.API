using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class WebsiteBalance
    {
        public decimal Websitebalanceid { get; set; }
        public decimal Websiteid { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? Lastupdated { get; set; }

        public virtual Website Website { get; set; } = null!;
    }
}
