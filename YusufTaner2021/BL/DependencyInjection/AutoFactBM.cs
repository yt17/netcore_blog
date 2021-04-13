using Autofac;
using BL.Abstract;
using BL.Concrete;
using Core.JWT;
using DAL.Abstract;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.DependencyInjection
{
    public class AutoFactBM:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDAL>().As<IProductDAL>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDAL>().As<IUserDAL>();
            
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JWTHELPER>().As<ITokenHelper>();

            //builder.RegisterType<EfOperationClaimDAL>().As<IOperationClaimDAL>();
            //builder.RegisterType<EfUserOperationClaimDAL>().As<IUserOperationClaim>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        }
    }
}
