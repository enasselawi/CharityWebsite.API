using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Data
{
    public class CharityCategoryWithCharities
    {
        public int CharityCategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CharityID { get; set; }
        public string CharityName { get; set; }
    }
}
