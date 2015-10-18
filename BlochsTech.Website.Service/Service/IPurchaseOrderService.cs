using BlochsTech.Website.Domain.EntityModel;
using BlochsTech.Website.Service.Common;

namespace BlochsTech.Website.Service.Service
{
    public interface IPurchaseOrderService : IEntityService<PurchaseOrder>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        PurchaseOrder GetById(int id);

        void CompleteOrder(int orderId, string transactionId);
    }
}
