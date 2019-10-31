using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.Id).HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IsEnabled).HasColumnName("IsEnabled");
            Property(x => x.IsDeleted).HasColumnName("IsDeleted");

            Property(x => x.UserCreated).HasColumnName("UserCreated");
            Property(x => x.TerminalCreated).HasColumnName("TerminalCreated");
            Property(x => x.DateCreated).HasColumnName("DateCreated");

            Property(x => x.UserModify).HasColumnName("UserModify");
            Property(x => x.TerminalModify).HasColumnName("TerminalModify");
            Property(x => x.DateModify).HasColumnName("DateModify");

            Property(x => x.UserDeleted).HasColumnName("UserDeleted");
            Property(x => x.TerminalDeleted).HasColumnName("TerminalDeleted");
            Property(x => x.DateDeleted).HasColumnName("DateDeleted");
        }
    }
}
