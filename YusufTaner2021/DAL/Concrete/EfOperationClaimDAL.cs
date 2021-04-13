using Core.Entity;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Concrete;
using DAL.Abstract;

namespace DAL.Concrete
{
    public class EfOperationClaimDAL : EfEntityRepositoryBase<OperationClaims, ProjectDbContext>, IOperationClaimDAL
    {
    }
}
