using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreFront1.Models; //always need this to use model as parameter in post

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStoreFront1.Controllers
{
    public class OrderController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(OrderViewModel model)
        {
            return this.RedirectToAction("Index", "Shipping");
        }
    }
}
