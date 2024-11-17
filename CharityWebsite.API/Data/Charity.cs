using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class Charity
    {
        public Charity()
        {
            Bankaccounts = new HashSet<Bankaccount>();
            DonationHistories = new HashSet<DonationHistory>();
            PaymentHistories = new HashSet<PaymentHistory>();
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
        public virtual ICollection<DonationHistory> DonationHistories { get; set; }
        public virtual ICollection<PaymentHistory> PaymentHistories { get; set; }
        public virtual ICollection<Problemreport> Problemreports { get; set; }
    }
}
