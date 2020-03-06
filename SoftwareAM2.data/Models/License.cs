using System;
using System.Collections.Generic;

namespace SoftwareAM2.data.Models
{
    public partial class License
    {
        public int LicenseId { get; set; }
        public DateTime? LisenseStart { get; set; }
        public DateTime? LisenseEnd { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
