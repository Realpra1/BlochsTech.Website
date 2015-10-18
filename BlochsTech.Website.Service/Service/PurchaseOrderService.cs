using BlochsTech.Website.DataAccess.Infrastructure;
using BlochsTech.Website.DataAccess.Repository;
using BlochsTech.Website.Domain.EntityModel;
using BlochsTech.Website.Service.Common;

namespace BlochsTech.Website.Service.Service
{
    public class PurchaseOrderService : EntityService<PurchaseOrder>, IPurchaseOrderService
    {
        IUnitOfWork _unitOfWork;
        IPurchaseOrderRepository _purchaseOrderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="purchaseOrderRepository">The purchase order repository.</param>
        public PurchaseOrderService(IUnitOfWork unitOfWork, IPurchaseOrderRepository purchaseOrderRepository)
            : base(unitOfWork, purchaseOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public PurchaseOrder GetById(int id)
        {
            return _purchaseOrderRepository.GetById(id);
        }

        public void CompleteOrder(int orderId, string transactionId)
        {
            PurchaseOrder order = _purchaseOrderRepository.GetById(orderId);
            order.Status = PurchaseOrderStatus.Paid;
            order.TransactionId = transactionId;
            _unitOfWork.Commit();
        }
    }
}
