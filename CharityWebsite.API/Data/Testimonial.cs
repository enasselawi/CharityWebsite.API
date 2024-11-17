using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class Testimonial
    {
        public decimal Testimonalid { get; set; }
        public string? Status { get; set; }
        public DateTime? Datecreated { get; set; }
        public decimal? Userid { get; set; }
        public string? Content { get; set; }

        public virtual Userr? User { get; set; }
    }
}
