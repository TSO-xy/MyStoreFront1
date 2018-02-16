using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStoreFront1.Controllers
{
    public class ProductsController : Controller
    {
        //Models.ProductsViewModel[] productArray = new Models.ProductsViewModel(); 

        //// GET: /<controller>/
        //public IActionResult Index(productArray)
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Index(int? id)
        {
            Console.WriteLine("GOT info");
            //move model instances here

            if (id == 1)
            {
                Models.ProductsViewModel model1 = new Models.ProductsViewModel();
                model1.ID = 1;
                model1.Name = "Jazz Pack";
                model1.Price = 39.99m;
                model1.Genre = "Jazz";
                model1.Description = "Use this to recreate the sharp, tangy sounds of Jazz music.";
                model1.ImageUrl = "/images/jazz.jpg";

                return View(model1);
            }

            if (id == 2)
            {
                Models.ProductsViewModel model2 = new Models.ProductsViewModel();
                model2.ID = 2;
                model2.Name = "Rock Pack";
                model2.Price = 29.99m;
                model2.Genre = "Rock";
                model2.Description = "Recreate the rugged sound of Rock music.";
                model2.ImageUrl = "/images/Rock.jpg";

                return View(model2);
            }

            else
            {
                Models.ProductsViewModel model1 = new Models.ProductsViewModel();
                model1.ID = 1;
                model1.Name = "Jazz Pack";
                model1.Price = 39.99m;
                model1.Genre = "Jazz";
                model1.Description = "Use this to recreate the sharp, tangy sounds of Jazz music.";
                model1.ImageUrl = "/images/jazz.jpg";
                return View(model1);
            }

        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            //Cookies: useful for saving small pieces of data
            string cartId;
            if(!Request.Cookies.ContainsKey("cartId"))
            {
                cartId = Guid.NewGuid().ToString();
                Response.Cookies.Append("cartId", cartId, new Microsoft.AspNetCore.Http.CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1)
                });
            }
            else
            {
                Request.Cookies.TryGetValue("cartId", out cartId);
            }
            Console.WriteLine("cart");
            //Console.WriteLine("Added {0} to cart {1}", cartId);
            //TODO: Need to create a record in the database that
            //corresponds to this cart ID, and add the product to that cart



            return RedirectToAction("Index", "Shipping");
        }
    }
}
