using Ninject.Modules;
using OnlineShop.Libs.Data.Contracts;
using OnlineShop.Libs.Data;
using Ninject.Web.Common;
using Ninject;
using OnlineShop.ConfigurationProviders.Contracts;
using Ninject.Parameters;
using Ninject.Extensions.Factory;
using OnlineShop.Libs.Models.Contracts;

namespace OnlineShop.Configuration.NinjectConfigs
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<EfOnlineShopDbContext>().ToSelf().InRequestScope();

            this.Kernel.Bind(typeof(IEfOnlineShopDbContext),
                                typeof(IEfEntryProvider),
                                typeof(IEfUnitOfWork))
                                .ToMethod(ctx =>
                                {
                                    var connectionString = ctx.Kernel.Get<IConnectionStringProvider>().ConnectionString;

                                    var ctorArg = new ConstructorArgument("connectionString", connectionString);

                                    var db = ctx.Kernel.Get<EfOnlineShopDbContext>(ctorArg);

                                    return db;
                                }).InRequestScope();

            this.Kernel.Bind(typeof(IEfQuerable<>)).To(typeof(EfQuerable<>)).InRequestScope();
        }
    }
}
