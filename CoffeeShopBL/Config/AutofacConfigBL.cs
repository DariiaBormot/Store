using Autofac;
using CoffeeShopDAL;
using CoffeeShopDAL.Interfaces;
using CoffeeShopDAL.Repositories;

namespace CoffeeShopBL.Config
{
    public class AutofacConfigBL : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<CoffeeShopContext>().InstancePerLifetimeScope();
        }
    }
}
