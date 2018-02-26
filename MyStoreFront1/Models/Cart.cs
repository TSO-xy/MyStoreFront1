using System;
using System.Collections.Generic;

namespace MyStoreFront1.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartProducts = new HashSet<CartProducts>();
        }

        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastModified { get; set; }

        public ICollection<CartProducts> CartProducts { get; set; }
    }
}
