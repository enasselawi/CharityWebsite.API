using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Data
{
    public class CharityCategoryWithPaidCharities
    {
        public int CharityCategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CharityId { get; set; }
        public string CharityName { get; set; }
        public string Status { get; set; }
    }
}
