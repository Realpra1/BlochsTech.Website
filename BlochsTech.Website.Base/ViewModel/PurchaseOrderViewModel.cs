using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlochsTech.Website.Base.ViewModel
{
    public enum CardType
    {
        SimpleCard
    }
    /// <summary>
    ///  Purchase order view model class.
    /// </summary>
    public class PurchaseOrderViewModel
    {
        public PurchaseOrderViewModel()
        {
            this.CardTypes = new List<SelectListItem>();    
            this.CardTypes.Add(new SelectListItem() { Value = CardType.SimpleCard.ToString(), Text = "Normal card"});
        }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Recipient Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Street and number")]
        public string Sreet { get; set; }

        [MaxLength(100)]
        [Display(Name = "Apt./Unit")]
        public string Apartament { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State/Region")]
        public string State { get; set; }

        public string Country { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Confirm Email")]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "The Email and confirmation Email do not match.")]
        public string ConfirmEmail { get; set; }

        public CardType CardType { get; set; }

        public List<SelectListItem> CardTypes { get; set; }
    }
}