using System;
using System.Collections.Generic;

namespace RegisterCompanyAndAuth.Models
{
    public partial class Companies
    {
        public Companies()
        {
            Users = new HashSet<Users>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Database { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
