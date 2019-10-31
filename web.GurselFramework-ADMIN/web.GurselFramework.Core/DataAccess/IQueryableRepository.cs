using System.Linq;
using web.GurselFramework.Core.Entities;

namespace web.GurselFramework.Core.DataAccess
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}
