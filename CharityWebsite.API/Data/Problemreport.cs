using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class Problemreport
    {
        public decimal Problemreportid { get; set; }
        public string? Description { get; set; }
        public string? Imagepath { get; set; }
        public DateTime? Datesubmitted { get; set; }
        public string? Status { get; set; }
        public string? Problemtype { get; set; }
        public decimal? Userid { get; set; }
        public decimal? Charityid { get; set; }

        public virtual Charity? Charity { get; set; }
        public virtual Userr? User { get; set; }
    }
}
