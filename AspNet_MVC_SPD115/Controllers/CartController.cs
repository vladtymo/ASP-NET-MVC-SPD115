using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using AspNet_MVC_SPD115.Helpers;
using DataAccess.Data;

namespace AspNet_MVC_SPD115.Controllers
{
    public class CartController : Controller
    {
        const string cartItemsKey = "cart_items";
        private readonly Shop115DbContext ctx;

        public CartController(Shop115DbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            var ids = HttpContext.Session.Get<List<int>>(cartItemsKey) ?? new();

            var products = ctx.Products.Where(x => ids.Contains(x.Id)).ToList();

            return View(products);
        }

        public IActionResult Add(int id)
        {
            var ids = HttpContext.Session.Get<List<int>>(cartItemsKey) ?? new();

            ids.Add(id);

            HttpContext.Session.Set(cartItemsKey, ids);

            return RedirectToAction("Index", "Home");
        }
    }
}
