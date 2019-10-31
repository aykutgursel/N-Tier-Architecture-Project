using System.Data.Entity;
using web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<SalesOffer> SalesOffer { get; set; }
        public DbSet<Menu> Menu { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ProductImagesMap());
            modelBuilder.Configurations.Add(new SalesOfferMap());
            modelBuilder.Configurations.Add(new MenuMap());
        }
    }
}
