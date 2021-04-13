using Core.Entity;
using DAL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity.Concrete;

namespace DAL.Concrete
{
    public class EfProductDAL : EfEntityRepositoryBase<Product, ProjectDbContext>, IProductDAL
    {
    }
}
