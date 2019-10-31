using System.Collections.Generic;
using web.GurselFramework.Core.DataAccess.NHibernate;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : NhEntityRepositoryBase<Product>, IProductDal
    {
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }

        public List<CategoryProductDetail> GetCategoryProductDetails(string categoryUrl)
        {
            throw new System.NotImplementedException();
        }

        public List<ProductDetail> GetProductDeails()
        {
            throw new System.NotImplementedException();
        }
    }
}
