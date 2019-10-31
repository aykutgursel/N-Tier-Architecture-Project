using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Get()
        {
            return _productService.GetAll();
        }
    }
}
