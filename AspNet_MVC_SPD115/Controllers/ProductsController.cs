using AspNet_MVC_SPD115.Data;
using AspNet_MVC_SPD115.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        // GET: show creation form
        [HttpGet]
        public IActionResult Create()
        {
            // Ways of sending data to View
            // 1 - using View(model)
            // 2 - using TemoData: this.TempData["key"] = value
            // 3 - using ViewBag: this.ViewBag.Property = value
            this.ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            // create product in db
            ctx.Products.Add(product);
            ctx.SaveChanges();

            return RedirectToAction("Index");
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
