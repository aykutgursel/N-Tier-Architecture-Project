using System.Data.Entity.ModelConfiguration;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductImagesMap : EntityTypeConfiguration<ProductImages>
    {
        public ProductImagesMap()
        {
                ToTable(@"ProductImages", @"dbo").
                    HasKey(x => x.Id);

                Property(x => x.Id).HasColumnName("Id");
                Property(x => x.ImagePath).HasColumnName("ImagePath");
                Property(x => x.Url).HasColumnName("Url");
                Property(x => x.Keywords).HasColumnName("Keywords");
        }
    }
}
