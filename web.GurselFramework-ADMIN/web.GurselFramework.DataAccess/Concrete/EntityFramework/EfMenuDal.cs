using web.GurselFramework.Core.DataAccess.EntityFramework;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework
{
    public class EfMenuDal : EfEntityRepositoryBase<Menu, NorthwindContext>, IMenuDal
    {
    }
}
