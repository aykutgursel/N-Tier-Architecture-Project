namespace web.GurselFramework.Entities.Concrete
{
    public class Menu : BaseEntity
    {
        public virtual string MenuName { get; set; }
        public virtual string MenuUrl { get; set; }
        public virtual string MenuIcon { get; set; }
        public virtual int? MasterMenuId { get; set; }
        public virtual bool ShowMenu { get; set; }
    }
}
