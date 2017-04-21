using MyShop.Models;
using MyShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        DataService _dataService = new DataService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var review = _dataService.GetReview();
            ViewBag.Quote = review.Quote;
            ViewBag.Source = review.Source;
            review.Clear();

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Give us feedback";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(Message message)
        {
            ViewBag.Message = "Thank you for your message";
            MailService ms = new MailService();
            ms.SendMail(message.MessageText, message.Email);
            return View(message);
        }
    }
}