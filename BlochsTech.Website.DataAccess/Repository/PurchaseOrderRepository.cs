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

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<PurchaseOrder> GetAll()
        {
            return _entities.Set<PurchaseOrder>().AsEnumerable();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public PurchaseOrder GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
