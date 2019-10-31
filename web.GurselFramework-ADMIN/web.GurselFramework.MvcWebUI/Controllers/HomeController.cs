using FluentValidation.Results;
using System.Web.Mvc;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.Business.ServiceModel;
using web.GurselFramework.Business.ValidationRules.FluentValidation;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.MvcWebUI.Controllers
{
    public class HomeController : BaseController
    {
        private IMenuService _menuService;
        private IProductService _productService;

        public HomeController(IMenuService menuService, IProductService productService)
        {
            _menuService = menuService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            var data = new object();
            var url = "";
            var operation = this.PostType<ServiceResult<int>>(url, data);


            //return View(_productService.Add(new Product()));
            return View();
        }
    }
}