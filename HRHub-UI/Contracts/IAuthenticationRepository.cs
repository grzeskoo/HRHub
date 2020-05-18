using HRHub_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_UI.Contracts
{
    interface IAuthenticationRepository
    {
        public Task<bool> Register(RegisterModel user);

        public Task<bool> Login(LoginModel user);

        public Task  Logout();
    }
}
