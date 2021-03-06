﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreFront1.Models; //always need this to use model as parameter in post
using Microsoft.EntityFrameworkCore;

namespace MyStoreFront1.Controllers
{
    public class OrderController : Controller
    {
        private JoshTestContext _context;

        public OrderController(JoshTestContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            string cartId;
            Guid trackingNumber;
            OrderViewModel order = new OrderViewModel();

            if (Request.Cookies.TryGetValue("cartId", out cartId) && Guid.TryParse(cartId, out trackingNumber) && _context.Cart.Any(x => x.TrackingNumber == trackingNumber))
            {
                var cart = _context.Cart.Include(x => x.CartProducts).ThenInclude(y => y.Products).Single(x => x.TrackingNumber == trackingNumber);
                order.CartProducts = cart.CartProducts.ToArray();
            }

            return View(order);

        }
        [HttpPost]
        public IActionResult Remove(int productId)
        {
            string cartId;
            Guid trackingNumber;
            if (Request.Cookies.TryGetValue("cartId", out cartId) && Guid.TryParse(cartId, out trackingNumber) && _context.Cart.Any(x => x.TrackingNumber == trackingNumber))
            {

                var cart = _context.Cart.Include(x => x.CartProducts).ThenInclude(y => y.Products).Single(x => x.TrackingNumber == trackingNumber);
                var cartItem = cart.CartProducts.Single(x => x.Products.Id == productId);

                cartItem.Quantity = 0;
                _context.CartProducts.Remove(cartItem);

                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            _context.SaveChanges();
            return this.RedirectToAction("Index", "Shipping");
        }
    }
}
