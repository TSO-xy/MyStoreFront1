using System;
namespace MyStoreFront1.Models
{
    public class LineItem
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public Products Product { get; set; }
        public Order Order { get; set; }

    }
}
