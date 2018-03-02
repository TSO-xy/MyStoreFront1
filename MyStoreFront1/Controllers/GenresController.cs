using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreFront1.Models;

namespace MyStoreFront1.Controllers
{
    public class GenresController : Controller
    {
        private JoshTestContext _context;

        public GenresController(JoshTestContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products;
            return View(products);
        }
    }
}
