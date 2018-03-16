using System;
using System.ComponentModel.DataAnnotations; //used for [Required]

namespace MyStoreFront1.Models
{
    public class ShippingViewModel
    {
        //Shipping
        [Required]
        public string ShippingName { get; set; }

        [Required]
        public string ShippingStreet { get; set; }

        [Required]
        public string ShippingCity { get; set; }

        [Required]
        public string ShippingState { get; set; }

        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please use a 5 or 9 digit zip code")]
        [Required]
        public int? ShippingZipCode { get; set; }

        [Required]
        public string DeliveryMethod { get; set; }

        //Billing
        [Required]
        public string CreditCardName { get; set; }

        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Required]
        public string CVV { get; set; }

        [Required]
        public string ExpMonth { get; set; }

        [Required]
        public string ExpYear { get; set; }

        [Required]
        public string BillingStreet { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string BillingCity { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string BillingState { get; set; }

        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please use a 5 or 9 digit zip code")]
        [Required]
        public string BillingZipCode { get; set; }

        public SavedCreditCard[] SavedCreditCards { get; set; }

        public string CardToken { get; set; }
    }

    public class SavedCreditCard
    {
        public string LastFour { get; set; }
        public string Token { get; set; }
    }

}