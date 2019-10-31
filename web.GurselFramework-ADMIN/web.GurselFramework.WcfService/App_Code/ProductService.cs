using System;
using System.Collections.Generic;
using System.Linq;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.Business.DependencyResolvers.Ninject;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Entities.Concrete;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService : IProductService
{
    public ProductService()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public void TransactionalOperation(Product product1, Product product2)
    {
        _productService.TransactionalOperation(product1, product2);
    }

    public Product Update(Product product)
    {
        return _productService.Update(product);
    }

    public List<Product> GetLastEight()
    {
        throw new NotImplementedException();
    }

    public Product GetByUrl(string url)
    {
        return _productService.GetByUrl(url);
    }

    public List<CategoryProductDetail> GetCategoryProductDetails(string categoryUrl)
    {
        return _productService.GetCategoryProductDetails(categoryUrl);
    }
}