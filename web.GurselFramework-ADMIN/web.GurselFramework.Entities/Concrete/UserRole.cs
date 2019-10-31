using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
