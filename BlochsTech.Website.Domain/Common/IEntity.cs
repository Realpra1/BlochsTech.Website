using System;

namespace BlochsTech.Website.Domain.Common
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime UpdatedDate { get; set; }
    }
}
