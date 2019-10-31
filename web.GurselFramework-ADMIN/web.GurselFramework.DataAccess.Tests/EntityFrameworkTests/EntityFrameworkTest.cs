using Microsoft.VisualStudio.TestTools.UnitTesting;
using web.GurselFramework.DataAccess.Concrete.EntityFramework;

namespace web.GurselFramework.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_product()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList();

            Assert.AreEqual(1, result.Count);
        }
        public void Get_all_with_parameter_returns_filtered_products()
        {
            EfProductDal productDal = new EfProductDal();
            var result = productDal.GetList(x => x.Name.Contains("ab"));

            Assert.AreEqual(1, result.Count);
        }

    }
}
