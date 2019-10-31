using System.Linq;
using web.GurselFramework.Core.DataAccess.EntityFramework;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework
{
    public class EfProductImagesDal : EfEntityRepositoryBase<ProductImages, NorthwindContext>, IProductImagesDal
    {
        public string ImageProductName(ProductImages productImages)
        {
            using (NorthwindContext database = new NorthwindContext())
            {
                var _productImageName = database.ProductImages.Where(x => x.Id == productImages.Id)
                    .Select(x => x.Keywords).FirstOrDefault();

                return _productImageName;
            }
        }
    }
}
