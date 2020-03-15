using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonWebToken.Request;

namespace JsonWebToken.Service
{
    public class UserService : IUserService
    {
        public bool IsValid(LoginRequestDTO req)
        {
            return true;
        }
    }
}
