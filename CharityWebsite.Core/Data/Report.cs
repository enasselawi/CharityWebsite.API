using System;
using System.Collections.Generic;

namespace CharityWebsite.Core.Data
{
    public partial class Report
    {
        public decimal Reportid { get; set; }
        public string? Reporttype { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string? Reportcontent { get; set; }
        public decimal? Userid { get; set; }

        public virtual Userr? User { get; set; }
    }
}
