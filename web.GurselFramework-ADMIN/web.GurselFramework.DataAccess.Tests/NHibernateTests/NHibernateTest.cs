using Microsoft.VisualStudio.TestTools.UnitTesting;
using web.GurselFramework.DataAccess.Concrete.NHibernate;
using web.GurselFramework.DataAccess.Concrete.NHibernate.Helpers;

namespace web.GurselFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_all_returns_all_product()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();

            Assert.AreEqual(1, result.Count);
        }
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(x => x.Name.Contains("ab"));

            Assert.AreEqual(1, result.Count);
        }

    }
}
