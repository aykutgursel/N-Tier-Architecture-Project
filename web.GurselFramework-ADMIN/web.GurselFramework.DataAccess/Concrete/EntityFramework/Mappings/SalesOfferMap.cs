using System.Data.Entity.ModelConfiguration;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class SalesOfferMap: EntityTypeConfiguration<SalesOffer>
    {
        public SalesOfferMap()
        {
            ToTable(@"SalesOffer", @"dbo").
             HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.ProductId).HasColumnName("ProductId");
            Property(x => x.ProductName).HasColumnName("ProductName");
            Property(x => x.NameSurname).HasColumnName("NameSurname");
            Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.Message).HasColumnName("Message");
        }
    }
}
