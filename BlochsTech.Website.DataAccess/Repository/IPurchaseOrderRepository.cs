using BlochsTech.Website.DataAccess.Infrastructure;
using BlochsTech.Website.Domain.EntityModel;

namespace BlochsTech.Website.DataAccess.Repository
{
    public interface IPurchaseOrderRepository : IGenericRepository<PurchaseOrder>
    {
        PurchaseOrder GetById(int id);
    }
}
