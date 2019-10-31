using System.Collections.Generic;
using web.GurselFramework.Core.DataAccess;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDeails();
        List<CategoryProductDetail> GetCategoryProductDetails(string categoryUrl);
    }
}
