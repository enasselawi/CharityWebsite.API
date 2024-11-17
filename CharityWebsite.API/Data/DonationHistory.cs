using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class DonationHistory
    {
        public decimal Donationid { get; set; }
        public decimal Userid { get; set; }
        public decimal Charityid { get; set; }
        public decimal Donationamount { get; set; }
        public DateTime? Donationdate { get; set; }
        public string? Donationtype { get; set; }

        public virtual Charity Charity { get; set; } = null!;
        public virtual Userr User { get; set; } = null!;
    }
}
