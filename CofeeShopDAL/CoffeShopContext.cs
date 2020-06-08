using CofeeShopDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CofeeShopDAL
{
    public class CoffeShopContext : DbContext
    {
        public CoffeShopContext(DbContextOptions<CoffeShopContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

    }
}
