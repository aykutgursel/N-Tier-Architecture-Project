using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Entities.Concrete
{
    public class Category : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Url { get; set; }
        public virtual bool IsMenu { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int? SortOrder { get; set; }
        public virtual int? MasterId { get; set; }
    }
}
