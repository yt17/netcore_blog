using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Concrete
{
    public class OperationClaims : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
