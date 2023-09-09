using AspNet_MVC_SPD115.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNet_MVC_SPD115.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            // code...
            return this.View(); // ~/Views/Home/Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}