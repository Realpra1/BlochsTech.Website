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

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable<TEntity>();
        }

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TEntity Add(TEntity entity)
        {
            return _dbset.Add(entity);
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public virtual TEntity Delete(TEntity entity)
        {
            return _dbset.Remove(entity);
        }

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Edit(TEntity entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
