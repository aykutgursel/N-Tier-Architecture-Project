using web.GurselFramework.Core.DataAccess;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Abstract
{
    public interface IProductImagesDal : IEntityRepository<ProductImages>
    {
        string ImageProductName(ProductImages productImages);
    }
}
