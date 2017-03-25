using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;
using OnlineShop.Libs.Services;
using OnlineShop.Libs.Services.Contracts;

namespace OnlineShop.Configuration.NinjectConfigs
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IProductService>().To<ProductService>().InRequestScope();

            //this.Kernel.Bind(x =>
            //        x.FromAssemblyContaining<IService>()
            //        .SelectAllClasses()
            //        .InheritedFrom<IService>()
            //        .BindDefaultInterfaces()
            //        .Configure(z => z.InRequestScope())
            //    );
        }
    }
}
