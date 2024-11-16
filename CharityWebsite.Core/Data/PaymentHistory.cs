using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class PaymentHistory
    {
        public decimal Paymentid { get; set; }
        public decimal Userid { get; set; }
        public decimal Charityid { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Paymentdate { get; set; }
        public string? Paymentstatus { get; set; }

        public virtual Charity Charity { get; set; } = null!;
        public virtual Userr User { get; set; } = null!;
    }
}
