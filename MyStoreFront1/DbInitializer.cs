using System;
using System.Linq;
using MyStoreFront1.Models;

namespace MyStoreFront1
{
    internal class DbInitializer
    {
        internal static void Initialize(JoshTestContext context)
        {
            //Making sure database exists
            context.Database.EnsureCreated();

            if (!context.Genres.Any())
            {
                context.Genres.Add(new Genres
                {
                    Name = "Jazz",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "Rock",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "Hip Hop",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "Electronic",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "FX",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Products
                {
                    Name = "Jazz Strings",
                    Price = 49.99m,
                    Description = "A collection of silky smooth Jazz samples.",
                    ImageUrl = "/images/jazz.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
                context.Products.Add(new Products
                {
                    Name = "Jazz Drums",
                    Price = 29.99m,
                    Description = "Recreate the sharp, tangy sounds of classic Jazz drumkits.",
                    ImageUrl = "/images/jazzdrums.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
                context.Products.Add(new Products
                {
                    Name = "Rock Drums",
                    Price = 19.99m,
                    Description = "Recreate the rugged drumkits of Rock music.",
                    ImageUrl = "/images/rock.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
                context.Products.Add(new Products
                {
                    Name = "Boom Bap Pack",
                    Price = 14.99m,
                    Description = "Bring back the sounds of the Golden Age of Hip Hop.",
                    ImageUrl = "/images/hiphop.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
                context.Products.Add(new Products
                {
                    Name = "808 Drums",
                    Price = 14.99m,
                    Description = "Full array of professional drum sounds for New Age Hip Hop",
                    ImageUrl = "/images/808.png",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
            }

            context.SaveChanges();
        }
    }
}