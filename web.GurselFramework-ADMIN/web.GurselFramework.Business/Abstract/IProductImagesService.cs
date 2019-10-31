using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Abstract
{
    public interface IProductImagesService
    {
        List<ProductImages> GetList(Expression<Func<ProductImages, bool>> filter = null);
        ProductImages Get(Expression<Func<ProductImages, bool>> filter);
        ProductImages Add(ProductImages entity);
        ProductImages Update(ProductImages entity);
        void Delete(ProductImages entity);
        string GetProductIamgesKeywords(ProductImages productImages);
    }
}
