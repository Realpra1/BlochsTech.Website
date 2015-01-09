using System.ComponentModel.DataAnnotations;
using BlochsTech.Website.Domain.Common;
using System;

namespace BlochsTech.Website.Domain.EntityModel
{
   public class PurchaseOrder : Entity
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Recipient Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Sreet { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apartament { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

    }
}
