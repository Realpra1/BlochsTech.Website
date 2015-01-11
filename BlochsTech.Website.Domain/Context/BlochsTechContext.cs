using System;
using System.Data.Entity;
using System.Linq;
using BlochsTech.Website.Domain.Common;
using BlochsTech.Website.Domain.EntityModel;

namespace BlochsTech.Website.Domain.Context
{
    public class BlochsTechContext : DbContext
    {
        public BlochsTechContext()
            : base("Name=BlochsTechContext")
        {
        }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as IEntity;
                if (entity != null)
                {
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }

    }
}
