using System;
namespace MyStoreFront1.Models
{
    public class ProductsViewModel
    {
            public int ID { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Genre { get; set; }
            public string Description { get; set;}
            public string ImageUrl { get; set; }

    }
}
