using AutoMapper;
using System.Collections.Generic;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Concrete.Managers
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public Category Add(Category category)
        {
            return _mapper.Map<Category>(_categoryDal.Add(category));
        }

        public List<Category> GetAll()
        {
            return _mapper.Map<List<Category>>(_categoryDal.GetList());
        }

        public Category GetById(int id)
        {
            return _mapper.Map<Category>(_categoryDal.Get(x => x.Id == id));
        }

        public Category Update(Category category)
        {
            return _mapper.Map<Category>(_categoryDal.Update(category));
        }
    }
}
