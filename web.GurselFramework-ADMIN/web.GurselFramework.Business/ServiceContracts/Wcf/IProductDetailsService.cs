using System.Collections.Generic;
using System.ServiceModel;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.ServiceContracts.Wcf
{
    [ServiceContract]
    public interface IProductDetailsService
    {
            [OperationContract]
            List<Product> GetAll();
    }
}
