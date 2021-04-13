﻿using Core.Entity;
using Core.Entity.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IUserDAL : IRepository<User>
    {
        List<OperationClaims> GetOperationClaims(User user);
    }
}