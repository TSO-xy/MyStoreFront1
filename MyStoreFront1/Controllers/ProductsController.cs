using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyStoreFront1.Models;
using Microsoft.EntityFrameworkCore; //used for .Include

namespace MyStoreFront1.Controllers
{
    public class ProductsController : Controller
    {
        private JoshTestContext _context;

        public ProductsController(JoshTestContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string cartId;
            if (Request.Cookies.TryGetValue("cartId", out cartId))
            {

                var trackingGuid = Guid.Parse(cartId);
                var order = _context.Orders.Include(x => x.LineItems).ThenInclude(y => y.Product).Single(x => x.TrackingNumber == trackingGuid);
                ViewData["productName"] = order.LineItems.First().Product.Name;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var product = _context.Products.Include(x => x.Reviews).Single(x => x.Id == id);
            return View(product);

            //If View expects IEnumerable (Array of products)
            //if (id.HasValue)
            //{
            //    return View(_context.Products.Where(id == Id.Value));
            //}
            //else
            //{
            //    return View(_context.Products);
            //}
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            string cartId;
            if(!Request.Cookies.ContainsKey("cartId"))
            {
                var product = _context.Products.Find(id);
                Order o = new Order();
                LineItem l = new LineItem();
                l.Quantity = 1;
                l.Product = product;
                o.LineItems.Add(l);
                o.DateCreated = DateTime.UtcNow;
                o.Subtotal = product.Price ?? 0m;
                o.Tax = o.Subtotal * 0.1m;
                o.ShippingTotal = 7m;
                o.TrackingNumber = new Guid();

                _context.Orders.Add(o);
                _context.SaveChanges();
                cartId = o.TrackingNumber.ToString();

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
