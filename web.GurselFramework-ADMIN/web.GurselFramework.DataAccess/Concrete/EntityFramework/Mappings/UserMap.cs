using System.Data.Entity.ModelConfiguration;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo").
               HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.FirstName).HasColumnName("FirstName");
            Property(x => x.LastName).HasColumnName("LastName");
            Property(x => x.IsAdmin).HasColumnName("IsAdmin");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.UserName).HasColumnName("UserName");
            Property(x => x.Password).HasColumnName("Password");
        }
    }
}
