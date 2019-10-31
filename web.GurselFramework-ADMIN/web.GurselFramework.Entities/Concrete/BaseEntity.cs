using System;
using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Entities.Concrete
{
    public class BaseEntity : IEntity
    {
        public virtual int Id { get; set; }
        public virtual bool IsEnabled { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual int UserCreated { get; set; }
        public virtual string TerminalCreated { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual int? UserModify { get; set; }
        public virtual string TerminalModify { get; set; }
        public virtual DateTime? DateModify { get; set; }
        public virtual int? UserDeleted { get; set; }
        public virtual string TerminalDeleted { get; set; }
        public virtual DateTime? DateDeleted { get; set; }
    }
}
