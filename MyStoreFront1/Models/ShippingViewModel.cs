using System;
namespace MyStoreFront1.Models
{
    public class ShippingViewModel
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public DateTime? Date { get; set; }
    }
}