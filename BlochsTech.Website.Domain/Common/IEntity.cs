using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlochsTech.Website.Domain.Common
{
    public interface IEntity<T>
    {
        T Id { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
