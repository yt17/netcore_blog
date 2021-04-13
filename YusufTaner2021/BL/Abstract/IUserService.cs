using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Concrete;
namespace BL.Abstract
{
    public interface IUserService
    {
        List<OperationClaims> GetClaims(User user);
        void AddUser(User user);
        User GetUserByMail(string mail);
    }
}
