using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class Visacard
    {
        public decimal Visacardid { get; set; }
        public long? Cardnumber { get; set; }
        public DateTime? Expirydate { get; set; }
        public byte? Cvv { get; set; }
        public decimal? Balance { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Donationid { get; set; }
        public decimal? Userid { get; set; }

        public virtual Donation? Donation { get; set; }
        public virtual Userr? User { get; set; }
    }
}
