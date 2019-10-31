using System.Collections.Generic;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetLastEight();
        Product GetById(int id);
        Product GetByUrl(string url);
        Product Add(Product product);
        Product Update(Product product);
        void TransactionalOperation(Product product1, Product product2);
        List<CategoryProductDetail> GetCategoryProductDetails(string categoryUrl);
    }
}
