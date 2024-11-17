using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class Charitycategory
    {
        public Charitycategory()
        {
            Charities = new HashSet<Charity>();
        }

        public decimal Charitycategoryid { get; set; }
        public string? Categoryname { get; set; }

        public virtual ICollection<Charity> Charities { get; set; }
    }
}
