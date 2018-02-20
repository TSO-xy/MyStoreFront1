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
            //move model instances here
            Models.ProductsViewModel model = new Models.ProductsViewModel();

            string connectionString = "Data Source=localhost;Initial Catalog=JoshTest;Integrated Security=False;user=sa;password=P@ssw0rd!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var connection = new System.Data.SqlClient.SqlConnection(connectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Products WHERE ID = " + id.Value;
            var reader = command.ExecuteReader();
            var nameColumn = reader.GetOrdinal("Name");
            var priceColumn = reader.GetOrdinal("Price");
            var genereColumn = reader.GetOrdinal("Genre");
            var descriptionColumn = reader.GetOrdinal("Description");
            var imageUrlColumn = reader.GetOrdinal("ImageUrl");
            while (reader.Read())
            {
                model.Name = reader.GetString(nameColumn);
                model.Price = reader.GetDecimal(priceColumn);
                model.Genre = reader.GetString(genereColumn);
                model.Description = reader.GetString(descriptionColumn);
                model.ImageUrl = reader.GetString(imageUrlColumn);
            }

                //Models.ProductsViewModel model1 = new Models.ProductsViewModel();
                //model1.ID = 1;
                //model1.Name = "Jazz Pack";
                //model1.Price = 39.99m;
                //model1.Genre = "Jazz";
                //model1.Description = "Use this to recreate the sharp, tangy sounds of Jazz music.";
                //model1.ImageUrl = "/images/jazz.jpg";
                
            connection.Close();
            return View(model);

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
