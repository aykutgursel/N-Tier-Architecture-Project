using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.GurselFramework.Entities.ComplexTypes
{
    public class CategoryProductDetail
    {
        public virtual int CategoryId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual string ProductName { get; set; }
        public virtual string CategoryDescription { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual string CategoryUrl { get; set; }
        public virtual string ProductUrl { get; set; }
        public virtual string ProductImagePath { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual decimal? OldPrice { get; set; }
        public virtual string Keywords { get; set; }
        public virtual bool HidePrice { get; set; }
        public virtual bool Status { get; set; }

    }
}
