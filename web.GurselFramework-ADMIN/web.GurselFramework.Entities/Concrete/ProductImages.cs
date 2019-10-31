using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Entities.Concrete
{
    public class ProductImages : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string ImagePath { get; set; }
        public virtual string Url { get; set; }
        public virtual string Keywords { get; set; }
    }
}
