using NetCoreAngularTemplate.Data;
using NetCoreAngularTemplate.Data.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAngularTemplate.BussinesLogic
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext dbContext { get; set; }

        protected DbSet<TEntity> dbSet { get; set; }

        public GenericRepository(TestContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            this.dbContext = dbContext;
            dbSet = (DbSet<TEntity>)dbContext.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual Task<TEntity> GetByIdAsync(int id)
        {
            return dbSet.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                dbSet.Add(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            EntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }
        public IEnumerable<TEntity> GetAll() => dbSet.AsEnumerable();

        public virtual void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public virtual Task SaveChangesAsync()
        {
            return dbContext.SaveChangesAsync();
        }
    }
}
