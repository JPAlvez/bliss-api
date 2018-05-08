using System;
using System.Data.Entity;
using System.Linq;

namespace Bliss.Recruitment.Data.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; }
        protected IQueryable<TEntity> Query { get; }

        protected BaseRepository(DbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
            Query = DbSet.AsNoTracking();
        }

        public virtual TEntity Add(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                return DbSet.Add(entity);
            }

            dbEntityEntry.State = EntityState.Added;
            return dbEntityEntry.Entity;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
                return dbEntityEntry.Entity;
            }

            DbSet.Attach(entity);
            DbSet.Remove(entity);
            return entity;
        }

        public virtual TEntity TrackExisting(TEntity entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            if ((dbEntityEntry.State != EntityState.Added && dbEntityEntry.State != EntityState.Deleted) || dbEntityEntry.State == EntityState.Unchanged)
            {
                dbEntityEntry.State = EntityState.Modified;
            }

            return dbEntityEntry.Entity;
        }

        public virtual TEntity Get(long id)
        {
            var result = DbSet.Find(id);
            if (null != result)
            {
                var dbEntry = DbContext.Entry(result);
                dbEntry.State = EntityState.Detached;
            }
            return result;
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
