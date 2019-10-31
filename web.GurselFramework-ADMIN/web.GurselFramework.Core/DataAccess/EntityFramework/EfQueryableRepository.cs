using System.Data.Entity;
using System.Linq;
using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<T> _entities;

        public EfQueryableRepository(DbContext context) => _context = context;
        public IQueryable<T> Table => this.Entities;
        public virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }
    }
}
