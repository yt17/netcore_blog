using BL.Abstract;
using DAL.Abstract;
using Entity.Concrete;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDAL productDAL;
        public ProductManager(IProductDAL productDAL)
        {
            this.productDAL = productDAL;
        }
        
        public void Add(Product product)
        {
            productDAL.Add(product);
        }

        public void Delete(Product product)
        {
            productDAL.Delete(product);
        }       
        public void Update(Product product)
        {
            productDAL.Update(product);
        }

        Result<List<Product>> IProductService.GetList()
        {
            List<Product> lst= productDAL.GetList(null);       
            return new Result<List<Product>>(true,"tamam",lst);
        }

        Result<List<Product>> IProductService.GetListByCategory(int categoryId)
        {
            List<Product> lst = productDAL.GetList(w=>w.CategoryId==categoryId);        
            return new Result<List<Product>>(true, "tamam", lst);
        }
    }
}
