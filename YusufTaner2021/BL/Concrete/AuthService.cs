using BL.Abstract;
using Core.Entity.Concrete;
using Core.JWT;
using DAL.Abstract;
using Entity.DTO;
using Helper;
using Helper.HashingHelper;

using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserDAL userDAL;

        public AuthService(IUserService userService, ITokenHelper tokenHelper, IUserDAL userDAL)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            this.userDAL = userDAL;
        }
        public Result<User> Register(UserForRegisterDTO userForRegisterDto)
        {
            byte[] passworHash, passwordSalt;
            var sonuc = userExists(userForRegisterDto.Email);
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passworHash, out passwordSalt);
            User us = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passworHash,
                PasswordSalt = passwordSalt,
                Status = true

            };

            _userService.AddUser(us);
            return new Result<User>(true,"basarili", us);

        }

        public Result<User> Login(UserForLoginDTO userForLoginDto)
        {
            var usertocheck = _userService.GetUserByMail(userForLoginDto.Email);
            if (usertocheck == null)
            {
                return new Result<User>(false,"hata var",null);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, usertocheck.PasswordHash, usertocheck.PasswordSalt))
            {
                return new Result<User>(false, "hata var", null);
            }
            return new Result<User>(true, "basarili", usertocheck);

        }

        public Result<string> userExists(string mail)
        {
            var usertocheck = _userService.GetUserByMail(mail);
            if (usertocheck != null)
            {
                return new Result<string>(false,"hata var","");
            }

            return new Result<string>(true,"tamam","");


        }

        public Result<AccessToken> CreateAccestoken(User user)
        {
            var claims = userDAL.GetOperationClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, claims);
            return new Result<AccessToken>(true,"basarili",accessToken);
        }
    }
}
