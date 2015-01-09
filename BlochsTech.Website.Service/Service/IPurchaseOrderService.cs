using BlochsTech.Website.Domain.EntityModel;
using BlochsTech.Website.Service.Common;

namespace BlochsTech.Website.Service.Service
{
    public interface IPurchaseOrderService : IEntityService<PurchaseOrder>
    {
        PurchaseOrder GetById(int id);
    }
}
