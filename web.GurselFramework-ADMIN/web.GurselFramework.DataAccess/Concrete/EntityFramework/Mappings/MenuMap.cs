using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.DataAccess.Concrete.EntityFramework.Mappings
{
    public class MenuMap : BaseMap<Menu>
    {
        public MenuMap()
        {
            ToTable(@"Menu", @"dbo").
                   HasKey(x => x.Id);

            Property(x => x.MenuName).HasColumnName("MenuName");
            Property(x => x.MenuUrl).HasColumnName("MenuUrl");
            Property(x => x.MenuIcon).HasColumnName("MenuIcon");
            Property(x => x.MasterMenuId).HasColumnName("MasterMenuId");
            Property(x => x.ShowMenu).HasColumnName("ShowMenu");
        }
    }
}
