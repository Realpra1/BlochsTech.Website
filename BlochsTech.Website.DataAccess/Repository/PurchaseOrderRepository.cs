using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlochsTech.Website.DataAccess.Infrastructure;
using BlochsTech.Website.Domain.EntityModel;

namespace BlochsTech.Website.DataAccess.Repository
{
    public class PurchaseOrderRepository : GenericRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<PurchaseOrder> GetAll()
        {
            return _entities.Set<PurchaseOrder>().AsEnumerable();
        }

        public PurchaseOrder GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
