using Autofac;
using CofeeShopDAL.Interfaces;
using CofeeShopDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace CoffeeShopBL.Config
{
    public class AutofacConfigBL : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
        }
    }
}
