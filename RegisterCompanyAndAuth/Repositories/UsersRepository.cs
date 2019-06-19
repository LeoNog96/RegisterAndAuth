using RegisterCompanyAndAuth.Models;
using RegisterCompanyAndAuth.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterCompanyAndAuth.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CompaniesContext _db;

        public UsersRepository(CompaniesContext db)
        {
            _db = db;
        }

        public async Task<Users> Save (Users user)
        {
            var entity = await _db.Users.AddAsync(user);

            await _db.SaveChangesAsync();

            return entity.Entity;
        }
    }
}
