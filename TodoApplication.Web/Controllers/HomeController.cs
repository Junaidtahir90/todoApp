using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Web.Models;

namespace TodoApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return RedirectResult("tasks/");
            return Redirect("Task/Index");
           // return RedirectToAction("Index", TaskController);
            //return View();
            //
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
