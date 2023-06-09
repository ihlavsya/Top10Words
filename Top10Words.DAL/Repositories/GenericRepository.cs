using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top10Words.DAL.EFCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Top10Words.DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dataContext;
        protected readonly DbSet<TEntity> _dbset;

        public GenericRepository(DbContext context)
        {
            _dataContext = context;
            _dbset = _dataContext.Set<TEntity>();
        }
        public virtual async Task Create(TEntity entity)
        {
            _dbset.Add(entity);
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            TEntity item = _dbset.Find(id);
            if (item != null)
            {
                _dbset.Remove(item);
                await _dataContext.SaveChangesAsync();
            }
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _dbset.Where(predicate);
        }

        public TEntity FindFirst(Func<TEntity, bool> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }
    }
}
