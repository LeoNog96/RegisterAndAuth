﻿using RegisterCompanyAndAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterCompanyAndAuth.Services.Interfaces
{
    public  interface IRegisterService
    {
        Task<Users> Register(Users user);
    }
}
