using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using RegisterCompanyAndAuth.Models;
using RegisterCompanyAndAuth.Repositories.Interfaces;
using RegisterCompanyAndAuth.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterCompanyAndAuth.Services
{
    public class RegisterService : IRegisterService
    {
        IUsersRepository _usersRepository;
        IConfiguration _config;

        public RegisterService(IUsersRepository usersRepository, IConfiguration config)
        {
            _usersRepository = usersRepository;
            _config = config;
        }

        public async Task<Users> Register(Users user)
        {
            if(user == null)
            {
                throw new Exception("Invalid User");
            }

            user.Company.Database = CreateContextMongo(user.Company.Name);

            if(user.Company.Database == null)
            {
                throw new Exception("Problema ao gerar Database");
            }

            return await _usersRepository.Save(user);
        }

        private string CreateContextMongo(string company)
        {
            var client = new MongoClient(_config.GetConnectionString("MongoDb"));

            var db = client.GetDatabase(company);

            db.CreateCollection("teste");
            db.CreateCollection("teste2");

            return _config.GetConnectionString("MongoDb") + "/" + company;
        }
    }
}
