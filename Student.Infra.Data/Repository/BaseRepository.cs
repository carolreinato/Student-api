using Microsoft.EntityFrameworkCore;
using Student.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Student.Infra.Data.Repository
{
    public class BaseRepository<TEntity>
    {
        protected BaseContext DbContext { get; private set; }

        public BaseRepository(BaseContext dbContext)
        {
            DbContext = dbContext;
        }

        protected IQueryable<T> GetAll<T>() where T : class, new()
        {
            return DbContext.Set<T>().AsQueryable();
        }
        protected IQueryable<T> Get<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            return DbContext.Set<T>().Where(predicate).AsQueryable();
        }

        protected void Insert<T>(T obj) where T : class, new()
        {
            DbContext.Add(obj);
        }

        protected async Task InsertAsync<T>(T obj, CancellationToken cancellationToken) where T : class, new()
        {
            await DbContext.AddAsync(obj, cancellationToken);

        }

        protected void Update<T>(T obj) where T : class, new()
        {
            //DbContext.Attach(obj);
            //DbContext.Entry<T>(obj).State = EntityState.Modified;
            DbContext.Update(obj);
        }

        protected void Delete<T>(object id) where T : class, new()
        {
            T existing = DbContext.Find<T>(id);
            DbContext.Remove(existing);
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
