using MyShop.Services;
using System.Web.Mvc;

namespace MyShop.Controllers
{
    public class PartnersController : Controller
    {
        private DataService _dataService = new DataService();
        // GET: Partner
        public ActionResult Index()
        {
            var partners = _dataService.GetAllPartners();
            return View(partners);
        }
    }
}