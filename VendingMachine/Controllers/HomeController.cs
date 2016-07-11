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
        BeverageService _beverageService = new BeverageService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var beverages = _beverageService.GetAll().Select(x=>new{Name =x.Name , Id=x.Id});
            return Json(new { beverages = beverages }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetRecipe(int id)
        {
            var recipe = _beverageService.GetRecipe(id).Select(x => new { Title = x.Title });
            return Json(new { recipe = recipe }, JsonRequestBehavior.AllowGet);
        }
    }
}