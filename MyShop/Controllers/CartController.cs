using MyShop.Models;
using MyShop.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class CartController : Controller
    {
        DataService _dataService = new DataService();
        // GET: Cart
        public ActionResult Index()
        {
            var products = _dataService.GetOrder();
            return View(products);
        }
        // GET: Cart/Order
        public ActionResult Order()
        {
            var email = GenerateOrderEmail();
            //TODO: Send email
            return View();
        }
        private string GenerateOrderEmail()
        {
            List<Product> products = new List<Product>();
            for(int i = 0; i < 3000; i++)
                products.Add(new Product() { ID = i, Name = "Product " + i, Image = "/Assets/Image" + i + ".png", Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla " });

            string emailBody = "<table><tr><td><B>Product ID</B></td><td><B>Product Name</B></td><td><B>Image</B></td><td><B>Description</B></td></tr>";
            foreach (var product in products)
            {
                emailBody += $"<tr><td>{product.ID}</td><td>{product.Name}</td><td><img src='{product.Image}'/></td><td>{product.Description}</td></tr>";
            }
            emailBody += "</table>";
            return emailBody;
        }
    }
}