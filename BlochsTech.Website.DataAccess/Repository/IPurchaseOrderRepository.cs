using BlochsTech.Website.DataAccess.Infrastructure;
using BlochsTech.Website.Domain.EntityModel;

namespace BlochsTech.Website.DataAccess.Repository
{
    public interface IPurchaseOrderRepository : IGenericRepository<PurchaseOrder>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        PurchaseOrder GetById(int id);
    }
}
