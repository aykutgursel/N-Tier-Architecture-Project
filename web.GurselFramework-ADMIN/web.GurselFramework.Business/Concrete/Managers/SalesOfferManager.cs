using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.GurselFramework.Business.Abstract;
using web.GurselFramework.DataAccess.Abstract;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Concrete.Managers
{
    public class SalesOfferManager : ISalesOfferService
    {
        private ISalesOfferDal _salesOfferDal;
        private readonly IMapper _mapper;

        public SalesOfferManager(ISalesOfferDal salesOfferDal, IMapper mapper)
        {
            _salesOfferDal = salesOfferDal;
            _mapper = mapper;
        }


        public SalesOffer Add(SalesOffer salesOffer)
        {
            return _mapper.Map<SalesOffer>(_salesOfferDal.Add(salesOffer));
        }

        public List<SalesOffer> GetAll()
        {
            return _mapper.Map<List<SalesOffer>>(_salesOfferDal.GetList());

        }

        public SalesOffer GetById(int id)
        {
            return _mapper.Map<SalesOffer>(_salesOfferDal.Get(x => x.Id == id));
        }

        public SalesOffer Update(SalesOffer salesOffer)
        {
            return _mapper.Map<SalesOffer>(_salesOfferDal.Update(salesOffer));
        }
    }
}
