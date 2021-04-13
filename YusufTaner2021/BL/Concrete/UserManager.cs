using BL.Abstract;
using DAL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using Core.Entity.Concrete;
using System.Text;
using System.Linq.Expressions;

namespace BL.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDAL userDAL;
        public UserManager(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public void AddUser(User user)
        {
            userDAL.Add(user);
        }

        public List<OperationClaims> GetClaims(User user)
        {
            return userDAL.GetOperationClaims(user);
        }

        public User GetUserByMail(string mail)
        {             
            //return userDAL.Get(w => w.Email == mail);
            var res=userDAL.Get(x=>(x.Email==mail));
            return res;
        }
    }
}
