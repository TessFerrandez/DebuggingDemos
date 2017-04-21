using System;
using System.Web.Caching;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class NewsController : Controller
    {
        int[] bits = new int[1000];

        public void RemovedCallback(String k, Object v, System.Web.Caching.CacheItemRemovedReason r)
        {
            //do stuff when the item is removed
        }

        // GET: News
        public ActionResult Index()
        {
            string news = "Site launched in December 2016";
            string key = Guid.NewGuid().ToString();
            ViewBag.News = news;

            System.Web.HttpContext.Current.Cache.Add(key, news, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 5, 0), CacheItemPriority.NotRemovable, new CacheItemRemovedCallback(this.RemovedCallback));
            return View();
        }
    }
}