using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
