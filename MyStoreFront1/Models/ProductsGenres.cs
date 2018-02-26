using System;
using System.Collections.Generic;

namespace MyStoreFront1.Models
{
    public partial class ProductsGenres
    {
        public int ProductId { get; set; }
        public int GenreId { get; set; }

        public Genres Genre { get; set; }
        public Products Product { get; set; }
    }
}
