using Core.Entity.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class ProjectDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-120BN2A;Database=Northwind;Integrated Security=SSPI");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
    }
}
