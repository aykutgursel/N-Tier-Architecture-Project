using System.Collections.Generic;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category Add(Category category);
        Category Update(Category category);
    }
}
