using System.Collections.Generic;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Abstract
{
    public interface ISalesOfferService
    {
        List<SalesOffer> GetAll();
        SalesOffer GetById(int id);
        SalesOffer Add(SalesOffer salesOffer);
        SalesOffer Update(SalesOffer salesOffer);
    }
}
