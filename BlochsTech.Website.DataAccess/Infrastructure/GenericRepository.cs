using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlochsTech.Website.Domain.Common;

namespace BlochsTech.Website.DataAccess.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
      where TEntity : Entity
    {

        protected DbContext _entities;
        protected readonly IDbSet<TEntity> _dbset;

        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable<TEntity>();
        }

        public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _dbset.Add(entity);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
