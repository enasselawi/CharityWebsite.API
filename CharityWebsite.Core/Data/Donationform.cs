using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Donationform
    {
        public Donationform()
        {
            Donations = new HashSet<Donation>();
        }

        public decimal Donationformid { get; set; }
        public string? Objectname { get; set; }
        public string? Description { get; set; }
        public string? Imagepath { get; set; }
        public string? Status { get; set; }
        public decimal? Charityid { get; set; }

        public virtual Charity? Charity { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }
}
