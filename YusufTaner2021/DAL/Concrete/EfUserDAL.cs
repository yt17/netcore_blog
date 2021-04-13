using Core.Entity;
using DAL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Entity.Concrete;

namespace DAL.Concrete
{
    public class EfUserDAL : EfEntityRepositoryBase<User, ProjectDbContext>, IUserDAL
    {

        public List<OperationClaims> GetOperationClaims(User user)
        {
            
            using (var context = new ProjectDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaims
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
               
                return result.ToList();
            }
        }

    }
}

