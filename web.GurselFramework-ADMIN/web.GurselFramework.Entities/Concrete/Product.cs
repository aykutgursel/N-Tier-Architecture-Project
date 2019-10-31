using System;
using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Entities.Concrete
{
    public class Product : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string Url { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ProductDescription { get; set; }
        public virtual string ProductInfo { get; set; }
        public virtual Int16 UnitsInStock { get; set; }
        public virtual string Quantity { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual bool HidePrice { get; set; }
        public virtual decimal? OldPrice { get; set; }
        public virtual bool Status { get; set; }
        public virtual string Keywords { get; set; }
    }
}
