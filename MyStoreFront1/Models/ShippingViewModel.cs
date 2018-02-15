using System;
using System.ComponentModel.DataAnnotations; //used for [Required]

namespace MyStoreFront1.Models
{
    public class ShippingViewModel
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [System.ComponentModel.DataAnnotations.RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Please use a 5 or 9 digit zip code")]
        [Required]
        public int? ZipCode { get; set; }

        [Required]
        public DateTime? Date { get; set; }
    }
}