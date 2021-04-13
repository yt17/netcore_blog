using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public int QuantityperUnit { get; set; }
        public int UnitPrice { get; set; }
    }
}
