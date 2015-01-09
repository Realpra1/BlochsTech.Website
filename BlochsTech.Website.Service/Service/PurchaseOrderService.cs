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

        public PurchaseOrderService(IUnitOfWork unitOfWork, IPurchaseOrderRepository purchaseOrderRepository)
            : base(unitOfWork, purchaseOrderRepository)
        {
            _unitOfWork = unitOfWork;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public PurchaseOrder GetById(int id)
        {
            return _purchaseOrderRepository.GetById(id);
        }
    }
}
