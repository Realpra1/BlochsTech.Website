using BlochsTech.Website.Domain.Common;

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

    }
}
