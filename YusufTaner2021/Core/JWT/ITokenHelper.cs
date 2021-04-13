using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateAccessToken(User user, List<OperationClaims> claims);
    }
}
