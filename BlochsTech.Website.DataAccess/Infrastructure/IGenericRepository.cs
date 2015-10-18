using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlochsTech.Website.Domain.Common;

namespace BlochsTech.Website.DataAccess.Infrastructure
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Finds the by.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        TEntity Delete(TEntity entity);

        /// <summary>
        /// Edits the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Edit(TEntity entity);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}
