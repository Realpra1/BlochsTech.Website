using System;

namespace BlochsTech.Website.Domain.Common
{
    public abstract class Entity<T> : IEntity<T>
    {
        public virtual T Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
