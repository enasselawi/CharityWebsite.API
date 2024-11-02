using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Invoice
    {
        public decimal Invoiceid { get; set; }
        public string? Emailsent { get; set; }
        public DateTime? Datesent { get; set; }
        public decimal? Userid { get; set; }

        public virtual Userr? User { get; set; }
    }
}
