using System.Collections.Generic;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.Business.DependencyResolvers.Ninject;
using web.GurselFramework.Business.ServiceContracts.Wcf;
using web.GurselFramework.Entities.Concrete;

/// <summary>
/// Summary description for ProductDetailService
/// </summary>
public class ProductDetailService : IProductDetailsService
{
    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

}