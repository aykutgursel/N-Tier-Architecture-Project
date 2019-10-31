using System.Collections.Generic;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Abstract
{
    public interface IMenuService
    {
        List<Menu> GetAll();
        Menu GetById(int id);
        Menu Add(Menu model);
        Menu Update(Menu model);
    }
}
