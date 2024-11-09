using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Userr
    {
        public Userr()
        {
            Charities = new HashSet<Charity>();
            DonationHistories = new HashSet<DonationHistory>();
            Donations = new HashSet<Donation>();
            Invoices = new HashSet<Invoice>();
            Problemreports = new HashSet<Problemreport>();
            Reports = new HashSet<Report>();
            Testimonials = new HashSet<Testimonial>();
            Visacards = new HashSet<Visacard>();
        }

        public decimal Userid { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Imagepath { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Charity> Charities { get; set; }
        public virtual ICollection<DonationHistory> DonationHistories { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Problemreport> Problemreports { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Visacard> Visacards { get; set; }
    }
}
