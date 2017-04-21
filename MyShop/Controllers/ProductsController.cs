using MyShop.Services;
using System;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class ProductsController : Controller
    {
        DataService _dataService = new DataService();
        // GET: Products
        public ActionResult Index()
        {
            var startTime = DateTime.Now;
            ViewBag.StartTime = startTime.ToLongTimeString();

            var products = _dataService.GetAllProducts(true);

            var endTime = DateTime.Now;
            var elapsedTime = endTime.Subtract(startTime);
            ViewBag.ElapsedTime = elapsedTime.Seconds + "." + elapsedTime.Milliseconds + "s";
            return View(products);
        }
    }
}