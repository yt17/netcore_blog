using Core.Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using Core.Entity.Concrete;
using System.Text;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class EfUserOperationClaimDAL: EfEntityRepositoryBase<UserOperationClaims, ProjectDbContext>, IUserOperationClaim
    {
    }
}
