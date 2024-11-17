using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class Bankaccount
    {
        public decimal Bankid { get; set; }
        public decimal? Balance { get; set; }
        public decimal? Charityid { get; set; }
        public decimal? Websiteid { get; set; }

        public virtual Charity? Charity { get; set; }
        public virtual Website? Website { get; set; }
    }
}
