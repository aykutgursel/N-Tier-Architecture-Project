using System.Data.Entity.ModelConfiguration;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo").
                HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.Name).HasColumnName("Name");
            Property(x => x.Description).HasColumnName("Description");
            Property(x => x.IsActive).HasColumnName("IsActive");
            Property(x => x.IsMenu).HasColumnName("IsMenu");
            Property(x => x.SortOrder).HasColumnName("SortOrder");
            Property(x => x.Url).HasColumnName("Url");
            Property(x => x.MasterId).HasColumnName("MasterId");
        }
    }
}
