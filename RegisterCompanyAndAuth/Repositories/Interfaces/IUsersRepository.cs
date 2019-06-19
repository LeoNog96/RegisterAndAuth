using RegisterCompanyAndAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterCompanyAndAuth.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> Save(Users user);
    }
}
