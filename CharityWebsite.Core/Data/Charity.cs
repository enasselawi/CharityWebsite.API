using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Charity
    {
        public Charity()
        {
            Bankaccounts = new HashSet<Bankaccount>();
            Donationforms = new HashSet<Donationform>();
            Donations = new HashSet<Donation>();
            Problemreports = new HashSet<Problemreport>();
        }

        public decimal Charityid { get; set; }
        public string? Charityname { get; set; }
        public string? Charitydescription { get; set; }
        public string? Location { get; set; }
        public string? Goals { get; set; }
        public string? Status { get; set; }
        public DateTime? Dateadded { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Charitycategoryid { get; set; }
        public string? Mission { get; set; }

        public virtual Charitycategory? Charitycategory { get; set; }
        public virtual Userr? User { get; set; }
        public virtual ICollection<Bankaccount> Bankaccounts { get; set; }
        public virtual ICollection<Donationform> Donationforms { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Problemreport> Problemreports { get; set; }
    }
}
