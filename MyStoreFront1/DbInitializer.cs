using System;
using System.Linq;
using MyStoreFront1.Models;
using Microsoft.EntityFrameworkCore;

namespace MyStoreFront1
{
    internal class DbInitializer
    {
        internal static void Initialize(JoshTestContext context)
        {
            //Making sure database exists
            //context.Database.EnsureCreated();
            context.Database.Migrate();

            if (!context.Genres.Any())
            {
                context.Genres.Add(new Genres
                {
                    Name = "Jazz",
                    ImageUrl = "/images/jazzgenre.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "Rock",
                    ImageUrl = "/images/rockgenre.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "Hip Hop",
                    ImageUrl = "/images/hiphopgenre.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "Electronic",
                    ImageUrl = "/images/electronicgenre.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
                context.Genres.Add(new Genres
                {
                    Name = "FX",
                    ImageUrl = "/images/FXgenre.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now
                });
            }
            context.SaveChanges();

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
                    //TODO: Add to a Genre category
                    Genre = context.Genres.First(x => x.Name == "Jazz")

                });
                context.Products.Add(new Products
                {
                    Name = "Jazz Drums",
                    Price = 29.99m,
                    Description = "Recreate the sharp, tangy sounds of classic Jazz drumkits.",
                    ImageUrl = "/images/jazzdrums.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    Genre = context.Genres.First(x => x.Name =="Jazz")
                });
                context.Products.Add(new Products
                {
                    Name = "Rock Drums",
                    Price = 19.99m,
                    Description = "Recreate the rugged drumkits of Rock music.",
                    ImageUrl = "/images/rock.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    Genre = context.Genres.First(x => x.Name == "Rock")
                });
                context.Products.Add(new Products
                {
                    Name = "Boom Bap Pack",
                    Price = 14.99m,
                    Description = "Bring back the sounds of the Golden Age of Hip Hop.",
                    ImageUrl = "/images/hiphop.jpg",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    Genre = context.Genres.First(x => x.Name == "Hip Hop")
                });
                context.Products.Add(new Products
                {
                    Name = "808 Drums",
                    Price = 14.99m,
                    Description = "Full array of professional drum sounds for New Age Hip Hop",
                    ImageUrl = "/images/808.png",
                    DateCreated = DateTime.Now,
                    DateLastModified = DateTime.Now,
                    Genre = context.Genres.First(x => x.Name == "Hip Hop")
                });
            }
            context.SaveChanges();
            if (!context.Reviews.Any())
            {
                context.Reviews.Add(new Review
                {
                    Rating = 5,
                    Body = "Totally worth the money!",
                    IsApproved = true,
                    Product = context.Products.First(), //adds review to 1st product in database

                });
            }
            context.SaveChanges();
        }
    }
}