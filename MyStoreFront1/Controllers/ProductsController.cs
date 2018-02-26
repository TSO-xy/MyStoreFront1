using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyStoreFront1.Models;

namespace MyStoreFront1.Controllers
{
    public class ProductsController : Controller
    {
        private JoshTestContext _context;

        public ProductsController(JoshTestContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var product = _context.Products.Find(id);
            return View(product);

            //If View expects IEnumerable (Array of products)
            //if (id.HasValue)
            //{
            //    return View(_context.Products.Where(id == id.Value));
            //}
            //else
            //{
            //    return View(_context.Products);
            //}
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
