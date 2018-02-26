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
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Products
                {
                    Name = "Jazz Pack",
                    Price = 39.99m,
                    Description = "Recreate the sharp, tangy sounds of Jazz music.",
                    ImageUrl = "/images/jazz.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
                context.Products.Add(new Products
                {
                    Name = "Rock Pack",
                    Price = 39.99m,
                    Description = "Recreate the rugged sounds of Rock music.",
                    ImageUrl = "/images/rock.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
                context.Products.Add(new Products
                {
                    Name = "Hip Hop Pack",
                    Price = 39.99m,
                    Description = "Oldschool boom bap and new age 808s.",
                    ImageUrl = "/images/hiphop.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                });
            }

            context.SaveChanges();
        }
    }
}