using System.Collections.Generic;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.MvcWebUI.Models
{
    public class ProductImagesListViewModel
    {
        public Product Product { get; set; }
        public List<ProductImages> ProductImages { get; set; }
    }
}