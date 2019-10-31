using System.Data.Entity.ModelConfiguration;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Product", @"dbo").
                HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.Url).HasColumnName("Url");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.ProductDescription).HasColumnName("ProductDescription");
            Property(x => x.ProductInfo).HasColumnName("ProductInfo");
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock");
            Property(x => x.Quantity).HasColumnName("Quantity");
            Property(x => x.ImagePath).HasColumnName("ImagePath");
            Property(x => x.Price).HasColumnName("Price");
            Property(x => x.OldPrice).HasColumnName("OldPrice");
            Property(x => x.Status).HasColumnName("Status");
            Property(x => x.Keywords).HasColumnName("Keywords");
        }

    }
}
