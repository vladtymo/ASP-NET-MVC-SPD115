using AspNet_MVC_SPD115.Data;
using AspNet_MVC_SPD115.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC_SPD115.Controllers
{
    public class ProductsController : Controller
    {
        Shop115DbContext ctx = new Shop115DbContext();

        public IActionResult Index()
        {
            // get products from db
            var products = ctx.Products.ToList();
            
            return View(products); // set view mode
        }
    }
}
