using System;
using System.Collections.Generic;

namespace MyStoreFront1.Models
{
    public partial class Products
    {
        public Products()
        {
            CartProducts = new HashSet<CartProducts>();
            OrderProducts = new HashSet<OrderProducts>();
            //ProductsGenres = new HashSet<ProductsGenres>();
            Reviews = new HashSet<Review>();
            LineItems = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }
        public Genres Genre { get; set; }

        public ICollection<CartProducts> CartProducts { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
        //public ICollection<ProductsGenres> ProductsGenres { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}
