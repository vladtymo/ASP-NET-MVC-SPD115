using AspNet_MVC_SPD115.Data;
using AspNet_MVC_SPD115.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_MVC_SPD115.Controllers
{
    public class ProductsController : Controller
    {
        Shop115DbContext ctx = new Shop115DbContext();

        // show all products
        public IActionResult Index()
        {
            // get products from db
            var products = ctx.Products.ToList();
            
            return View(products); // set view mode
        }

        // delete product by ID
        public IActionResult Delete(int id)
        {
            var item = ctx.Products.Find(id);

            if (item == null) return NotFound(); // 404

            ctx.Products.Remove(item);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
