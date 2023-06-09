using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top10Words.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task Delete(int id);
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity FindFirst(Func<TEntity, bool> predicate);
    }
}
