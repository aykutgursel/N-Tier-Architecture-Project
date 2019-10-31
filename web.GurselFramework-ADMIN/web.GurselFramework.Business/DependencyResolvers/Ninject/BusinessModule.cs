using web.GurselFramework.Business.Abstract;
using web.GurselFramework.Business.Concrete.Managers;
using web.GurselFramework.Core.DataAccess;
using web.GurselFramework.Core.DataAccess.EntityFramework;
using web.GurselFramework.Core.DataAccess.NHibernate;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.DataAccess.Concrete.EntityFramework;
using web.GurselFramework.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;
using System.Data.Entity;

namespace web.GurselFramework.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<ISalesOfferService>().To<SalesOfferManager>().InSingletonScope();
            Bind<ISalesOfferDal>().To<EfSalesOfferDal>().InSingletonScope();

            Bind<IProductImagesService>().To<ProductImagesManager>().InSingletonScope();
            Bind<IProductImagesDal>().To<EfProductImagesDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope(); ;

            Bind<IMenuService>().To<MenuManager>().InSingletonScope(); ;
            Bind<IMenuDal>().To<EfMenuDal>().InSingletonScope(); ;

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
