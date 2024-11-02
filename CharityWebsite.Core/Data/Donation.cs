using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Donation
    {
        public Donation()
        {
            Visacards = new HashSet<Visacard>();
        }

        public decimal Donationid { get; set; }
        public string? Donationtype { get; set; }
        public DateTime? Donationdate { get; set; }
        public DateTime? Transactionstatus { get; set; }
        public decimal? Charityid { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Donationformid { get; set; }

        public virtual Charity? Charity { get; set; }
        public virtual Donationform? Donationform { get; set; }
        public virtual Userr? User { get; set; }
        public virtual ICollection<Visacard> Visacards { get; set; }
    }
}
