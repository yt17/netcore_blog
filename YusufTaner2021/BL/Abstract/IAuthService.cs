using Core.Entity.Concrete;
using Core.JWT;
using Entity.DTO;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IAuthService
    {
            Result<User> Register(UserForRegisterDTO userForRegisterDto);
            Result<User> Login(UserForLoginDTO userForLoginDto);
            Result<string> userExists(string mail);
            Result<AccessToken> CreateAccestoken(User user);
       
    }
}
