using System.ComponentModel.DataAnnotations.Schema;
using BlochsTech.Website.Domain.Common;
using BlochsTech.Website.Domain.Extensions;

namespace BlochsTech.Website.Domain.EntityModel
{
    /// <summary>
    /// Purchase order entity.
    /// </summary>
    public class PurchaseOrder : Entity
    {
        public string Name { get; set; }

        public string Sreet { get; set; }

        public string Apartament { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

        [Column("Status")]
        public string StatusString
        {
            get { return Status.ToString(); }
            private set { Status = EnumExtensions.ParseEnum<PurchaseOrderStatus>(value); }
        }

        [NotMapped]
        public PurchaseOrderStatus Status { get; set; }
        public string TransactionId { get; set; }
    }

    public enum PurchaseOrderStatus
    {
        Initial,
        Refunded,
        Paid
    }
}
