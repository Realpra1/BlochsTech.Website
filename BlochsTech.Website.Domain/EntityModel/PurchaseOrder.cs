using System.ComponentModel.DataAnnotations;
using BlochsTech.Website.Domain.Common;
using System;

namespace BlochsTech.Website.Domain.EntityModel
{
    public class PurchaseOrder : Entity
    {
        public string Name { get; set; }

        public string Sreet { get; set; }

        public string Apartament { get; set; }

        public int ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Email { get; set; }

    }
}
