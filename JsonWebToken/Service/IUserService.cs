using JsonWebToken.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebToken.Service
{
    public interface IUserService
    {
        bool IsValid(LoginRequestDTO req);
    }
}
