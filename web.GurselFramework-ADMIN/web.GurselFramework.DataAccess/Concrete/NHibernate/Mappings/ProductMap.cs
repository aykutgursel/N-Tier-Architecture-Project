using FluentNHibernate.Mapping;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.NHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");
            LazyLoad();
            Id(x => x.Id).Column("Id");

            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.Name).Column("Name");
            Map(x => x.Price).Column("Price");
            Map(x => x.Quantity).Column("Price");
        }

    }
}
