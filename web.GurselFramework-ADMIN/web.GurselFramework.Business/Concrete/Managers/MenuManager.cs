using AutoMapper;
using System.Collections.Generic;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Concrete.Managers
{
    public class MenuManager : IMenuService
    {
        private IMenuDal _menuDal;
        private readonly IMapper _mapper;

        public MenuManager(IMenuDal menuDal, IMapper mapper)
        {
            _menuDal = menuDal;
            _mapper = mapper;
        }

        public List<Menu> GetAll()
        {
            return _mapper.Map<List<Menu>>(_menuDal.GetList());
        }

        public Menu GetById(int id)
        {
            return _mapper.Map<Menu>(_menuDal.Get(x => x.Id == id));
        }

        public Menu Add(Menu model)
        {
            return _mapper.Map<Menu>(_menuDal.Add(model));
        }

        public Menu Update(Menu model)
        {
            return _mapper.Map<Menu>(_menuDal.Update(model));
        }

        public Menu TestManager()
        {
            return null;
        }
    }
}
