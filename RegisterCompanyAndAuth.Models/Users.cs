using System;
using System.Collections.Generic;

namespace RegisterCompanyAndAuth.Models
{
    public partial class Users
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long CompanyId { get; set; }

        public virtual Companies Company { get; set; }
    }
}
