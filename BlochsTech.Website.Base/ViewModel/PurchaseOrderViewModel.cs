using System.ComponentModel.DataAnnotations;

namespace BlochsTech.Website.Base.ViewModel
{
    public enum CardType
    {
        SimpleCard
    }
    public class PurchaseOrderViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Recipient Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Street")]
        public string Sreet { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Apt./Unit")]
        public string Apartament { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
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
        [Compare("Email", ErrorMessage = "The Email and confirmation Email do not match.")]
        public string ConfirmEmail { get; set; }

        public CardType CardType { get; set; }
    }
}