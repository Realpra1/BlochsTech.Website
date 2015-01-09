using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BlochsTech.Website.Domain.Common;

namespace BlochsTech.Website.DataAccess.Infrastructure
{
    public interface IGenericRepository<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);

        TEntity Delete(TEntity entity);

        void Edit(TEntity entity);

        void Save();
    }
}
