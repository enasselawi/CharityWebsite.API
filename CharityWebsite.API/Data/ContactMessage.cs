using System;
using System.Collections.Generic;

namespace CharityWebsite.API.Data
{
    public partial class ContactMessage
    {
        public decimal Messageid { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Subject { get; set; }
        public string? Messagecontent { get; set; }
        public DateTime? Datesubmitted { get; set; }
    }
}
