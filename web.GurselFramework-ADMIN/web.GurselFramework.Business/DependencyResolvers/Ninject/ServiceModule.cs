using Ninject.Modules;
using System;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.Core.Utilities.Common;

namespace web.GurselFramework.Business.DependencyResolvers.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
        }
    }
}
