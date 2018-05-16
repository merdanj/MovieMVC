/*
 * Author: Merdan Jumanov
 * Update Date: 11.05.18
 * This is Microsoft tutorial on ASP.NET MVC. 
 * I am doing it to refresh my memory on ASP.NET and learn MVC on ASP.NET
 * Hello World controller
 */

using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /HelloWorld/Welcome/
        public ActionResult Welcome(string name, int numTimes = 1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();
        }

    }
}