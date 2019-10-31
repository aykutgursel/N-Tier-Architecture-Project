using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel.DataAnnotations;
using web.GurselFramework.DataAccess.Abstract;

namespace web.GurselFramework.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_Validation_Check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            //ProductManager productManager = new ProductManager(mock.Object);

            //productManager.Add(new Product());
        }
    }
}
