using Entity.Concrete;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IProductService
    {
        Result<List<Product>> GetList();
        Result<List<Product>> GetListByCategory(int categoryId);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);

    }
}
