/*
 * Author: Merdan Jumanov
 * Update Date: 11.05.18
 * This is Microsoft tutorial on ASP.NET MVC. 
 * I am doing it to refresh my memory on ASP.NET and learn MVC on ASP.NET
 * Home controller
 */

using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}