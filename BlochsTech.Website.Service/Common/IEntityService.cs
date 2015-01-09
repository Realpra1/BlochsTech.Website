using System.Collections.Generic;
using BlochsTech.Website.Domain.Common;

namespace BlochsTech.Website.Service.Common
{
    public interface IEntityService<T> 
    where T : Entity
    {
        void Create(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAll();

        void Update(T entity);
    }
}
