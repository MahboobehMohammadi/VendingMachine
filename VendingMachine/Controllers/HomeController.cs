using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Services;
namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        IBeverageService _beverageService;
        public HomeController(IBeverageService beverageService)
        {
            _beverageService = beverageService;
        }

        public HomeController()
        {
            _beverageService = new BeverageService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var beverages = _beverageService.GetAll();
            return Json(new { beverages = beverages }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetRecipe(int id)
        {
            var recipe = _beverageService.GetRecipe(id);
            return Json(new { recipe = recipe }, JsonRequestBehavior.AllowGet);
        }
    }
}