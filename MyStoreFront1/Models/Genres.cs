using System;
using System.Collections.Generic;

namespace MyStoreFront1.Models
{
    public partial class Genres
    {
        public Genres()
        {
            ProductsGenres = new HashSet<ProductsGenres>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<ProductsGenres> ProductsGenres { get; set; }
    }
}
