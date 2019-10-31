using System.Collections.Generic;
using web.GurselFramework.Core.DataAccess.EntityFramework;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Entities.Concrete;
using System.Linq;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from ur in context.UserRoles
                             join r in context.Roles
                             on ur.RoleId equals r.Id
                             where ur.UserId == user.Id
                             select new UserRoleItem { RoleName = r.Name };
                return result.ToList();
            }
        }
    }
}
