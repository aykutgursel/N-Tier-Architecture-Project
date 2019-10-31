using web.GurselFramework.Core.DataAccess.NHibernate;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.NHibernate
{
    public class NhCategoryDal : NhEntityRepositoryBase<Category>, ICategoryDal
    {
        public NhCategoryDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }
    }
}
