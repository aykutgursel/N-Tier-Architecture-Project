using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Concrete.Managers
{
    public class ProductImagesManager : IProductImagesService
    {
        private IProductImagesDal _productImagesDal;
        private readonly IMapper _mapper;

        public ProductImagesManager(IProductImagesDal productImagesDal, IMapper mapper)
        {
            _productImagesDal = productImagesDal;
            _mapper = mapper;
        }

        public List<ProductImages> GetList(Expression<Func<ProductImages, bool>> filter = null)
        {
            return _productImagesDal.GetList(filter);
        }

        public ProductImages Get(Expression<Func<ProductImages, bool>> filter)
        {
            return _productImagesDal.Get(filter);
        }

        public ProductImages Add(ProductImages entity)
        {
            return _productImagesDal.Add(entity);
        }

        public ProductImages Update(ProductImages entity)
        {
            return _productImagesDal.Update(entity);
        }

        public void Delete(ProductImages entity)
        {
            _productImagesDal.Delete(entity);
        }

        public string GetProductIamgesKeywords(ProductImages productImages)
        {
            return _productImagesDal.ImageProductName(productImages);
        }
    }
}
