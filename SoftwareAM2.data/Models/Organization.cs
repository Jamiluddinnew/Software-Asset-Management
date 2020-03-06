using System;
using System.Collections.Generic;

namespace SoftwareAM2.data.Models
{
    public partial class Organization
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public int LicenseIdd { get; set; }

        public virtual License LicenseIddNavigation { get; set; }
    }
}
