using System.Collections.Generic;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.ComplexTypes;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName && u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
