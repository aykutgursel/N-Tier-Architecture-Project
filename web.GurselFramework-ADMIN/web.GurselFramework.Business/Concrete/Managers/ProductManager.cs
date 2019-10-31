using System.Collections.Generic;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;
using web.GurselFramework.Business.ValidationRules.FluentValidation;
using web.GurselFramework.Core.Aspects.Postsharp.CacheAspects;
using web.GurselFramework.Core.Aspects.Postsharp.TransactionAspects;
using web.GurselFramework.Core.Aspects.Postsharp.ValidationAspects;
using web.GurselFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using web.GurselFramework.Core.Aspects.Postsharp.PerformanceAspects;
using web.GurselFramework.Core.Aspects.Postsharp.AuthorizationAspects;
using System.Linq;
using AutoMapper;
using web.GurselFramework.Core.Utilities.Mappings;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using System.Web.Mvc;
using FluentValidation.Results;

namespace web.GurselFramework.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        //[SecuredOperation(Roles = "Admin,Editor,Student")]
        public List<Product> GetAll()
        {
            var products = _mapper.Map<List<Product>>(_productDal.GetList());
            return products;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            //Business Codes
            _productDal.Update(product2);
        }

        public List<Product> GetLastEight()
        {
            var p1 = _mapper.Map<List<Product>>(_productDal.GetList(x => x.CategoryId == 2).OrderByDescending(x => x.Id).Take(8));
            var p2 = _mapper.Map<List<Product>>(_productDal.GetList(x => x.CategoryId == 3).OrderByDescending(x => x.Id).Take(8));
            var p3 = _mapper.Map<List<Product>>(_productDal.GetList(x => x.CategoryId == 1045).OrderByDescending(x => x.Id).Take(8));
            var p4 = _mapper.Map<List<Product>>(_productDal.GetList(x => x.CategoryId == 1046).OrderByDescending(x => x.Id).Take(8));

            return p1.Concat(p2).Concat(p3).Concat(p4).ToList();
        }

        public Product GetByUrl(string url)
        {
            return _productDal.Get(p => p.Url == url);
        }

        public List<CategoryProductDetail> GetCategoryProductDetails(string categoryUrl)
        {
            return _productDal.GetCategoryProductDetails(categoryUrl);
        }
    }
}