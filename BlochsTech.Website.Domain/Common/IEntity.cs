using System;

namespace BlochsTech.Website.Domain.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
