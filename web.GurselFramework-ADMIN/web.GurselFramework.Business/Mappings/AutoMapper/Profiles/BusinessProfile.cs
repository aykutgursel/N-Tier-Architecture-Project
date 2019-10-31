using AutoMapper;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Product, Product>();
        }
    }
}
