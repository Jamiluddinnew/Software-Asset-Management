using System;
using System.Collections.Generic;
namespace SoftwareAM2.data.Models
{
    public partial class User
    {
        public User()
        {
            License = new HashSet<License>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public int? UserContact { get; set; }

        public virtual ICollection<License> License { get; set; }
    }
}
