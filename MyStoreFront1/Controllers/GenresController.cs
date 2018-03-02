using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStoreFront1.Models;
using Microsoft.EntityFrameworkCore;
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
            var genres = _context.Genres;
            return View(genres);
        }

        public IActionResult Details(string id)
        {
            var products = _context.Genres.Include(x => x.Products).Single(x => x.Name == id).Products;
            return View(products);
        }
    }
}
