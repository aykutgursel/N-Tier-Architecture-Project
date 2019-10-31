using FluentValidation;
using Ninject.Modules;
using web.GurselFramework.Business.ValidationRules.FluentValidation;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
