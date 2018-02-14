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
        Models.ProductsViewModel productArray = new  
        //ProductViewModel[] productArray = new ProductViewModel[2];

        //// GET: /<controller>/
        //public IActionResult Index(productArray)
        //{
        //    return View();
        //}

        public IActionResult Index(string id)
        {
            if (id == "1")
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

            if (id == "2")
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
    }
}
