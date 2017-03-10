using System;
using Ninject.Modules;
using OnlineShop.ConfigurationProviders.Contracts;
using OnlineShop.ConfigurationProviders;
using Ninject.Web.Common;

namespace OnlineShop.Configuration.NinjectConfigs
{
    public class ConfigurationProvidersNinJectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IConnectionStringProvider>().To<ConnectionStringProvider>().InRequestScope();
            this.Kernel.Bind<IEnvoirmentProvider>().To<EnvoirmentProvider>().InRequestScope();
        }
    }
}
