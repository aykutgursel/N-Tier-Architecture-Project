using System.Collections.Generic;
using System.Linq;
using web.GurselFramework.Core.DataAccess.EntityFramework;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<CategoryProductDetail>  GetCategoryProductDetails(string categoryUrl)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.Id
                             where c.Url == categoryUrl
                             select new CategoryProductDetail
                             {
                                 CategoryId = c.Id,
                                 ProductId = p.Id,
                                 CategoryName = c.Name,
                                 ProductName = p.Name,
                                 CategoryDescription = c.Description,
                                 ProductDescription = p.ProductDescription,
                                 CategoryUrl = c.Url,
                                 ProductUrl = p.Url,
                                 ProductImagePath = p.ImagePath,
                                 Price = p.Price,
                                 OldPrice = p.OldPrice,
                                 Keywords = p.Keywords,
                                 HidePrice = p.HidePrice,
                                 Status = p.Status
                             };

                return result.ToList();
            }
        }

        public List<ProductDetail> GetProductDeails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.Id
                             select new ProductDetail
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 CategoryName = c.Name
                             };

                return result.ToList();
            }


        }
    }
}
