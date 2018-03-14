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

        //public async Task<IActionResult> Index(int id = 1)
        //{
        //    var product = await _context.Products.AsNoTracking().Include(x => x.Reviews).SingleAsync(x => x.Id == id);
        //    string cartId;
        //    if (Request.Cookies.TryGetValue("cartId", out cartId))
        //    {

        //        var trackingGuid = Guid.Parse(cartId);
        //        var order = _context.Orders.Include(x => x.LineItems).ThenInclude(y => y.Product).Single(x => x.TrackingNumber == trackingGuid);
        //        ViewData["productName"] = order.LineItems.First().Product.Name;
        //    }
        //    return View(product);
        //}

        [HttpGet]
        public IActionResult Index(int id)
        {
            var product = _context.Products.Include(x => x.Reviews).Single(x => x.Id == id);
            return View(product);

        }

        [HttpPost]
        public async Task<IActionResult> Index(int id, bool extraParam = true)
        {
            Guid cartId;
            Cart c;
            CartProduct p;
             if(Request.Cookies.ContainsKey("cartId") && Guid.TryParse(Request.Cookies["cartId"], out cartId) && _context.Cart.Any(x => x.TrackingNumber == cartId))
            {
                c = _context.Cart
                    .Include(x => x.CartProducts)
                    .ThenInclude(y => y.Products)
                    .Single(x => x.TrackingNumber == cartId);
            }
            else
            {
                c = new Cart();
                cartId = Guid.NewGuid();
                c.TrackingNumber = cartId;
                _context.Cart.Add(c);
            }
            if (c.CartProducts.Any(x => x.Products.Id == id))
            {
                p = c.CartProducts.FirstOrDefault(x => x.Products.Id == id);
            }
            else
            {
                p = new CartProduct();
                p.Cart = c;
                p.ProductsId = id;
                c.CartProducts.Add(p);
            }
            p.Quantity++;

            await _context.SaveChangesAsync();
            Response.Cookies.Append("cartId", c.TrackingNumber.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                {
                Expires = DateTime.Now.AddMonths(1)
                });

            return RedirectToAction("Index", "Order");
        }
    }
}
