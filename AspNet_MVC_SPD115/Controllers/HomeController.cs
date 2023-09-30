using AspNet_MVC_SPD115.Models;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNet_MVC_SPD115.Controllers
{
    public class HomeController : Controller
    {
        private readonly Shop115DbContext ctx;

        public HomeController(Shop115DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            // code...
            return this.View(ctx.Products.ToList()); // ~/Views/Home/Index.cshtml
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