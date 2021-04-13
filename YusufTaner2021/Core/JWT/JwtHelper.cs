using Core.Entity.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.Extensions.Configuration.Binder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Extentions;
using System.Linq;

namespace Core.JWT
{
    public class JWTHELPER : ITokenHelper
    {
        public IConfiguration configuration_ { get; }
        private TokenOptions TokenOptions;
        DateTime EndTime;
        public JWTHELPER(IConfiguration configuration)
        {
            configuration_ = configuration;           
            TokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateAccessToken(User user,List<OperationClaims> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenOptions.SecurityKey));
            var SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreateJwtSecurityToken(user, TokenOptions, SigningCredentials, claims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                dateTime = EndTime
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(User user, TokenOptions tokenOptions, SigningCredentials signingCredentials, List<OperationClaims> claims)
        {
            EndTime = DateTime.Now.AddDays(tokenOptions.AccessTokenExpirarion);
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audince,
                expires: EndTime,
                notBefore: DateTime.Now,
                claims: SetClaims(user, claims),
                signingCredentials: signingCredentials

                );
            return jwt;

        }
        public IEnumerable<Claim> SetClaims(User user, List<OperationClaims> operations)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRole(operations.Select(w => w.Name).ToArray());
            return claims;

        }

    
    }
}
