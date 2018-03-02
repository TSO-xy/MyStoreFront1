using System;
using System.Collections.Generic;

namespace MyStoreFront1.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateLastModified { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
