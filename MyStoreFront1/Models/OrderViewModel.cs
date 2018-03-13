using System;
namespace MyStoreFront1.Models
{
    public class OrderViewModel
    {
        public CartProduct[] CartProducts { get; set; }
        public int Quantity { get; set; }
    }
}
